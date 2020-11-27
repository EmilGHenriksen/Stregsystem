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
        TransactionLogger transactionLogger = new TransactionLogger();
        public Stregsystem(FileReader fileHandler)
        {
            productsList = fileHandler.GenerateProductsList();
            usersList = fileHandler.GenerateUsersList();
        }

        public IEnumerable<Product> ActiveProducts { 

            get
            {
                List<Product> activeProducts = new List<Product>();
                foreach (Product product in productsList)     
                {
                    if (product.Active)
                    {
                        activeProducts.Add(product);
                    }
                }
                return activeProducts;
            }
        }
        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            InsertCashTransaction addCreditsToAccount = new InsertCashTransaction(user, amount, DateTime.Now);
            transactionsList.Insert(0, addCreditsToAccount.Execute(transactionLogger));
            return addCreditsToAccount;
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction buyTransaction = new BuyTransaction(user, product.Price, DateTime.Now, product.Price, product);
            transactionsList.Insert(0, buyTransaction.Execute(transactionLogger));
            return buyTransaction;
        }

        //Custom exception hvis hvis produktet ikke eksisterer. Denne exception indeholder information om produkt og beskrivende besked.
        //HVORDAN KAN DEN INDEHOLDE INFORMATION OM NOGET DER IKKE EKSISTERER
        public Product GetProductByID(int id)
        {
            foreach (Product product in productsList)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            throw new ProductDoesNotExistException("The specified product does not exist");
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
        //Lavet om fra User GetUsers til IEnumerable<User> GetUsers da det er flertal og giver mening det er en liste.
        public IEnumerable<User> GetUsers(Func<User, bool> predicate)
        {
            List<User> users = new List<User>();
            foreach (User user in usersList)
            {
                if (predicate(user))
                {
                    users.Add(user);
                }
            }
            return users;
        }

        //Custom exception hvis hvis user ikke eksisterer. Denne exception indeholder information om user og beskrivende besked.
        //HVORDAN KAN DEN INDEHOLDE INFORMATION OM NOGET DER IKKE EKSISTERER
        public User GetUserByUsername(string username)
        {
            foreach (User user in usersList)
            {
                if (user.Username == username)
                {
                    return user;
                }
            }
            throw new UserDoesNotExistException("The specified user does not exist");
        }
        //event UserBalanceNotification UserBalanceWarning;
    }
}
