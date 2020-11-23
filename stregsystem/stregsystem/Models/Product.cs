using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    public class Product
    {
        public Product(int id, string name, decimal price, bool active, bool canBeBoughtOnCredit)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("id", "Product ID cannot be less than 1");
            }
            else
                Id = id;
            Name = name;
            Price = price;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }     
        public bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Price;
        }
    }
}
