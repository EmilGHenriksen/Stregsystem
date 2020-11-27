using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal amount, DateTime date) : base(user, amount, date)
        {
        }
        public override Transaction Execute(TransactionLogger transactionLogger)
        {
            User.Balance += Amount;
            return this;
        }
        public override string ToString()
        {
            /*
                "A deposit of " + this.Amount + " stregdollars, has been made to user " + this.User.Username + " at " + this.Date + " with ID " + this.Id;
            */
            return "Deposit: " + "Amount: " + Amount + " User: " + User.ToString() + " Date: " + Date + " Id: " + Id; 
        }
    }
}
