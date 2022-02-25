using System;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Good
    {
        public int GoodId { get; set; }
        public string Name { get; set; }
        public int PriceId { get; set; }
        public int MyIntCol { get; set; }
        public string MyStrCol { get; set; }
        public string MyTextCol { get; set; }
        public Price Price { get; set; }
    }
}