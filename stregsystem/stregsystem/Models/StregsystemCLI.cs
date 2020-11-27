using System;
using System.Collections.Generic;
using System.Text;
using stregsystem.Interfaces;

namespace stregsystem.Models
{
    public class StregsystemCLI : IStregsystemUi
    {
        bool running = false;

        public StregsystemCLI(IStregsystem stregsystem)
        {
            Stregsystem = stregsystem;
        }
        private IStregsystem Stregsystem;

        public delegate void StregsystemEvent(string input);
        public event StregsystemEvent CommandEntered;

        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine("User " + username + " not found!");
        }
        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine("Product " + product + " not found!");
        }
        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user.ToString());
        }
        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine("Command " + command + " has too many arguments");
        }
        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine("Admin command " + adminCommand + " not found!");
        }
        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine("User " + transaction.User.Username + " bought " + transaction.Product + " for " + transaction.Product.Price);
        }
        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine("User " + transaction.User.Username + " bought " + count + "x " + transaction.Product + " for " + (count*transaction.Product.Price));
        }
        public void Close()
        {
            running = false;
            Environment.Exit(0);
        }
        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine("Your balance (" + user.Balance + " stregdollars) is too low to buy " + product.Name + " (Price: " + product.Price + ")");
        }
        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine("Error " + "\"" + errorString + "\"" + " occurred");
        }
        public void Start()
        {
            running = true;

            while (running)
            {
                DisplayActiveProducts();
                Console.WriteLine("Please enter a command: ");
                string userInput = Console.ReadLine();
                Console.Clear();
                CommandEntered?.Invoke(userInput);
            }
        }

        private void DisplayActiveProducts()
        {
            IEnumerable<Product> ActiveProducts = Stregsystem.ActiveProducts;
            foreach (Product product in ActiveProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
        }

        
        
    }
}
