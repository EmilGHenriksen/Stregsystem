using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace stregsystem.Models
{
    public class TransactionLogger
    {
        // " Price: " + Price + " User: " + User.ToString() + " Product: " + Product + " Date: " + Date + " ID: " + Id;
        public void WriteBuyTransactionToTransactionLog(BuyTransaction transaction)
        {
            string[] content = { "Price: " + transaction.Price + " User: " + transaction.User.ToString() + " Product: " + transaction.Product + " Date: " + transaction.Date + " ID: " + transaction.Id };

            File.AppendAllLines("transactionLog.txt", content);
        }
        // "Amount: " + Amount + " User: " + User.ToString() + " Date: " + Date + " Id: " + Id;
        public void WriteInsertCashTransactionToTransactionLog(InsertCashTransaction transaction)
        {
            string[] content = { transaction.Amount.ToString(), transaction.User.ToString(), transaction.Date.ToString(), transaction.Id.ToString()};

            File.AppendAllLines("transactionLog.txt", content);
        }
    }
}
