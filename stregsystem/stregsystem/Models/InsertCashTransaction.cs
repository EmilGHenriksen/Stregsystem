using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, int id, decimal amount, DateTime date) : base(user, id, amount, date)
        {
        }
        public override void Execute()
        {
            User.Balance += Amount;
        }
        public override string ToString()
        {
            /*
                "A deposit of " + this.Amount + " stregdollars, has been made to user " + this.User.Username + " at " + this.Date + " with ID " + this.Id
            */
            return "Deposit - " + "Amount: " + Amount + " User: " + User.ToString() + " Date: " + Date + " Id: " + Id;
        }
    }
}
