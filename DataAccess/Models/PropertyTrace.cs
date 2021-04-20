using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class PropertyTrace
    {
        public int IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        public int IdProperty { get; set; }

        public virtual Property IdPropertyNavigation { get; set; }
    }
}
