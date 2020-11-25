using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    public abstract class Transaction
    {
        static int nextId = 0;
        public Transaction (User user, decimal amount, DateTime date)
	{
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null");
            }
            else
            {
                User = user;
            }
            Id = nextId++;
            Amount = amount;
            Date = date;
	}

        public int Id { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public abstract void Execute();
        public override string ToString()
        {
            return Id + " " + User + " " + Amount + " " + Date;
        }

        //Id
        //user
        //date
        //amount
        //Tostring
        //Execute
    }
}
