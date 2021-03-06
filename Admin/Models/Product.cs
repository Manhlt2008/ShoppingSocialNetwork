﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class Product  : RecordInfo
    {
        public int ProductId { get; set; }
        public string ProTypeID { get; set; }
        public string ProTypeName { get; set; }
        public string Name { get; set; } 
        public double Price { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }    
    }
    public class ProductType
    {
        public int ProTypeId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
    }
}