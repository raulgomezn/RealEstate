using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace BusinessLayer.Tests
{
    [TestFixture()]
    public class RealEstateTests
    {
        [Test()]
        public void AllOwnerTest()
        {
            // Arrange
            DbContextOptions<TeamCityContext> options = new DbContextOptionsBuilder<TeamCityContext>()
                .UseSqlServer("AGREGAR CADENA DE CONEXION")
                .EnableSensitiveDataLogging()
                .Options;

            //Act
            var rta = new RealEstate().AllOwner();

            //Assert
            Assert.IsNotNull(rta);
        }
    }
}