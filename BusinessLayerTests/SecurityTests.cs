using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace BusinessLayer.Tests
{
    [TestFixture()]
    public class SecurityTests
    {
        private readonly TestServer testServer;

        public SecurityTests()
        {
            testServer = new TestServer(new WebHostBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json");
                })
                .UseStartup<Startup>());
        }

        [Test()]
        public void AuthenticateTest()
        {
            //Act
            var service = testServer.Services.GetRequiredService<ISecurity>();

            var test = new AuthRequest() { Username = "test", Password = "test" };
            var rta = service.Authenticate(test);

            //Assert
            Assert.IsNotNull(rta);
        }

        [Test()]
        public void AuthenticateFailTest()
        {
            //Act
            var service = testServer.Services.GetRequiredService<ISecurity>();

            var test = new AuthRequest() { Username = "t2est", Password = "t2est" };
            var rta = service.Authenticate(test);

            //Assert
            Assert.IsNull(rta);
        }
    }
}