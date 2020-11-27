using System;
using System.Collections.Generic;
using System.Text;
using stregsystem.Models;

namespace stregsystem.Interfaces
{
    public interface IStregsystemUi
    {
        void DisplayUserNotFound(string username);
        void DisplayProductNotFound(string product);
        void DisplayUserInfo(User user);
        void DisplayTooManyArgumentsError(string command);
        void DisplayAdminCommandNotFoundMessage(string adminCommand);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void Close();
        void DisplayInsufficientCash(User user, Product product);
        void DisplayInsufficientCash(User user, Product product, int count);
        void DisplayGeneralError(string errorString);
        void Start();
        public event StregsystemCLI.StregsystemEvent CommandEntered;
    }
}
