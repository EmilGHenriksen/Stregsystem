using System;
using System.Collections.Generic;
using System.Text;
using stregsystem.Interfaces;

namespace stregsystem.Models
{
    public class Stregsystem : IStregsystem
    {
        List<Product> productsList = new List<Product>();
        List<User> usersList = new List<User>();
        List<Transaction> transactionsList = new List<Transaction>();
        public Stregsystem(FileHandler fileHandler)
        {
            productsList = fileHandler.GenerateProductsList();
            usersList = fileHandler.GenerateUsersList();

        }

        public IEnumerable<Product> ActiveProducts { get; }
        public InsertCashTransaction AddCreditsToAccount(User user, int amount)
        {
            InsertCashTransaction addCreditsToAccount = new InsertCashTransaction(user, amount, DateTime.Now);
            return addCreditsToAccount;
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction buyTransaction = new BuyTransaction(user, product.Price, DateTime.Now, product.Price, product);
            return buyTransaction;
        }

        // TODO: Custom exception hvis hvis produktet ikke eksisterer. Denne exception indeholder information om produkt og beskrivende besked.
        public Product GetProductByID(int id)
        {
            foreach (Product product in productsList)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count, bool buyTransactionsOnly)
        {
            int transactionsFound = 0;
            List<Transaction> transactions = new List<Transaction>();
            foreach (Transaction transaction in transactionsList)
            {
                if (transaction.User.Equals(user) && (!buyTransactionsOnly || (transaction.GetType() == typeof(BuyTransaction))))
                {
                    transactionsFound++;
                    transactions.Add(transaction);
                    if (transactionsFound == count)
                    {
                        return transactions;
                    }
                }
            }
            return transactions;
        }
        public User GetUsers(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        // TODO: Custom exception hvis hvis user ikke eksisterer. Denne exception indeholder information om user og beskrivende besked.
        public User GetUserByUsername(string username)
        {
            foreach (User user in usersList)
            {
                if (user.Username == username)
                {
                    return user;
                }
            }
            throw new NotImplementedException();
        }
        // TODO: Make event on low userbalance
        //event UserBalanceNotification UserBalanceWarning;
    }
}
