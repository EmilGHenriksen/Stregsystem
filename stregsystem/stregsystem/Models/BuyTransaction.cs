using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    public class BuyTransaction : Transaction
    {
        public BuyTransaction(User user, decimal amount, DateTime date, decimal price, Product product) : base(user, amount, date)
        {
            Price = price;
            Product = product;
        }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public override void Execute()
        {
            //TODO: Lav insuficcientCreditsException
            if (User.Balance - Price < 0)
            {
                throw new NotImplementedException();
            }
            User.Balance -= Price;
        }
        public override string ToString()
        {
            return "Purchase - " + " Price: " + Price + " User: " + User.ToString() + " Product: " + Product + " Date: " + Date + " ID: " + Id;
        }
    }
}
