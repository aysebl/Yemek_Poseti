using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yemek_Poşeti.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
    }
}