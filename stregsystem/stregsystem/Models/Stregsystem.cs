using System;
using System.Collections.Generic;
using System.Text;

namespace stregsystem.Models
{
    class Stregsystem
    {
        IEnumerable<Product> ActiveProducts { get; }
        InsertCashTransaction AddCreditsToAccount(User user, int amount)
        {
            throw new NotImplementedException();
        }

        BuyTransaction BuyProduct(User user, Product product)
        {
            throw new NotImplementedException();
        }
        Product GetProductByID(int id)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            throw new NotImplementedException();
        }
        User GetUsers(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }
        User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }
        // TODO: Make event on low userbalance
        //event UserBalanceNotification UserBalanceWarning;
    }
}
