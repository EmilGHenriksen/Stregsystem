using System;
using System.Collections.Generic;
using System.Text;
using stregsystem.Models;

namespace stregsystem.Interfaces
{
    public interface IStregsystem
    {
        IEnumerable<Product> ActiveProducts { get; }
        InsertCashTransaction AddCreditsToAccount(User user, decimal amount);
        BuyTransaction BuyProduct(User user, Product product);
        Product GetProductByID(int id);
        IEnumerable<Transaction> GetTransactions(User user, int count, bool buyTransactionsOnly);
        IEnumerable<User> GetUsers(Func<User, bool> predicate);
        User GetUserByUsername(string username);
        event User.UserBalanceNotification UserBalanceNotification;
    }
}
