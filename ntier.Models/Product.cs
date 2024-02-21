﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntier.Models
{
    partial class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public double ListPrice { get; set; }
        public double Price { get; set; }
        public double Price50 { get; set; }
        public double Price100 { get; set; }
        public string ImgeUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
