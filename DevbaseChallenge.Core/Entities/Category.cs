using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DevbaseChallenge.Core.Entities
{
    public class Category : IEntity
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
