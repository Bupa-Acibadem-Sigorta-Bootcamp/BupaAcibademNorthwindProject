﻿using Northwind.EntityLayer.Concrete.Bases;

#nullable disable

namespace Northwind.EntityLayer.Concrete.Models
{
    public partial class ProductsAboveAveragePrice : EntityBase
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
