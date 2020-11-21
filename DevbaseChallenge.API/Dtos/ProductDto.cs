using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevbaseChallenge.API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
     
        public string Name { get; set; }
        //[Range(1,int.MaxValue,ErrorMessage = "{} alani 1 den buyuk bir deger olmalidir.")]
        public int Stock { get; set; }
        //[Range(1, double.MaxValue , ErrorMessage = "{} alani 1 den buyuk bir deger olmalidir.")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
