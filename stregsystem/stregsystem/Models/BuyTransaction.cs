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
        public override Transaction Execute(TransactionLogger transactionLogger)
        {
            if (User.Balance < Product.Price && !Product.CanBeBoughtOnCredit)
            {
                throw new InsufficientCreditsException("User has insufficient balance for product", User, Product);
            }
            if (!Product.Active)
            {
                throw new ProductNotActiveException("The product is not active", User, Product);
            }
            User.Balance -= Price;

            transactionLogger.WriteBuyTransactionToTransactionLog(this);
            return this;
            // TODO: UserBalanceNotification
        }
        public override string ToString()
        {
            return "Purchase: " + " Price: " + Price + " User: " + User.ToString() + " Product: " + Product.Name + " Date: " + Date + " Transaction ID: " + Id;
        }
    }
}
