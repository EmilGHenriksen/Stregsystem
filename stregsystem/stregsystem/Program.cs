using System;
using System.Collections.Generic;
using stregsystem.Interfaces;
using stregsystem.Models;

namespace stregsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fileHandler = new FileReader();
            IStregsystem stregsystem = new Stregsystem(fileHandler);
            IStregsystemUi ui = new StregsystemCLI(stregsystem);

            ui.Start();



            //User user = new User("Emil", "Henriksen", "H", 32m, "Em@il.dk");
            //Product product = new Product(1, "Ost", 10m, true, false);
            //BuyTransaction buy = new BuyTransaction(user, product.Price, DateTime.Now, product.Price, product);
            //BuyTransaction buy2 = new BuyTransaction(user, product.Price, DateTime.Now, product.Price, product);
            //TransactionLogger transactionLogger = new TransactionLogger();
            //buy.Execute(transactionLogger);
            //buy2.Execute(transactionLogger);
        }
    }
}
