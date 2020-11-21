using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    abstract class Transaction
    {
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
