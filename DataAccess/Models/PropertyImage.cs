using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class PropertyImage
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public string FileName { get; set; }
        public bool? Enable { get; set; }

        public virtual Property IdPropertyNavigation { get; set; }
    }
}
