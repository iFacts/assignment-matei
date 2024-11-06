using assignment_matei.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_matei.Models
{
    public partial class Item
    {
        public Item(string name, decimal price, Category category = Category.None, bool isImported = false)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
            this.IsImported = isImported;
        }

        public Item(string name, decimal price, bool isImported)
        {
            this.Name = name;
            this.Price = price;
            this.Category = Category.None;
            this.IsImported = isImported;
        }

        public Item(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.Category = Category.None;
            this.IsImported = false;
        }

        public string Name { get; set; }
        public decimal Price { get; set; } 
        public Category Category { get; set; }
        public bool IsImported { get; set; }
    }
}
