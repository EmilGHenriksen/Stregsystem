using System;
using System.Collections.Generic;
using System.Text;
using stregsystem.Interfaces;


namespace stregsystem.Models
{
    public class StregsystemCommandParser
    {
        /*
        :quit og :q skal afslutte programmet
        :activate og :deactivate (efterfulgt af produkt-id) skal henholdsvis aktivere og deaktivere et produkt (med mindre det er et seasonal produkt)
        :crediton og :creditoff (efterfulgt af produkt-id) skal henholdsvis aktivere og deaktivere om et produkt kan købes på kredit
        :addcredits (efterfulgt af brugernavn og tal) skal tilføje et antal credits til et brugernavns saldo
        */

        private delegate void adminCommand(string[] command);
        private Dictionary<string, adminCommand> adminCommands = new Dictionary<string, adminCommand>();
        

        public StregsystemCommandParser(IStregsystem stregsystem, IStregsystemUi stregsystemUi)
        {
            Stregsystem = stregsystem;
            StregsystemUi = stregsystemUi;

            GenerateAdminCommands();
            stregsystemUi.CommandEntered += ParseCommand;
        }
        private IStregsystem Stregsystem { get; }
        private IStregsystemUi StregsystemUi { get; }

        private void GenerateAdminCommands()
        {
            adminCommands.Add(":q", x => StregsystemUi.Close());
            adminCommands.Add(":quit", x => StregsystemUi.Close());
            adminCommands.Add(":activate", id => SetProductActive(id));
            adminCommands.Add(":deactivate", id => SetProductInactive(id));
            adminCommands.Add(":crediton", id => SetProductCreditOn(id));
            adminCommands.Add(":creditoff", id => SetProductCreditOff(id));
            adminCommands.Add(":addcredits", x => AddCreditsToUser(x));
        }
        private void ParseCommand(string input)
        {
            if (input.StartsWith(":"))
            {
                ParseAdminCommand(input);
            }
            else
                ParseUserCommand(input);
        }
        private void ParseAdminCommand(string command)
        {
            string[] splitCommand = command.Split(" ");
            if (adminCommands.ContainsKey(splitCommand[0]))
            {
                adminCommands[splitCommand[0]]?.Invoke(splitCommand);
            }
            else
                StregsystemUi.DisplayAdminCommandNotFoundMessage(command);
        }
        private void ParseUserCommand(string command)
        {
            string[] splitCommand = command.Split(" ");
            switch (splitCommand.Length)
            {
                case 1:
                    DisplayUserInfo(splitCommand[0]);
                    break;
                case 2:
                    BuyProduct(splitCommand[0], int.Parse(splitCommand[1]));
                    break;
                case 3:
                    BuyMultipleProducts(splitCommand[0], int.Parse(splitCommand[1]), int.Parse(splitCommand[2]));
                    break;
                default:
                    StregsystemUi.DisplayTooManyArgumentsError(command);
                    break;
            }
        }

        private void BuyMultipleProducts(string username, int id, int count)
        {
            try
            {
                User user = Stregsystem.GetUserByUsername(username);
                Product product = Stregsystem.GetProductByID(id);
                BuyTransaction buyTransaction = null;

                for (int i = 0; i < count; i++)
                {
                    buyTransaction = Stregsystem.BuyProduct(user, product);
                }
                StregsystemUi.DisplayUserBuysProduct(count, buyTransaction);
            }
            catch (UserDoesNotExistException)
            {
                StregsystemUi.DisplayGeneralError("User does not exist");
            }
            catch (ProductDoesNotExistException)
            {
                StregsystemUi.DisplayGeneralError("Product does not exist");
            }
        }
        private void BuyProduct(string username, int id)
        {
            try
            {
                User user = Stregsystem.GetUserByUsername(username);
                Product product = Stregsystem.GetProductByID(id);
                BuyTransaction buyTransaction = Stregsystem.BuyProduct(user, product);
                StregsystemUi.DisplayUserBuysProduct(buyTransaction);
            }
            catch (UserDoesNotExistException)
            {
                StregsystemUi.DisplayGeneralError("User does not exist");
            }
            catch (ProductDoesNotExistException)
            {
                StregsystemUi.DisplayGeneralError("Product does not exist");
            }
            catch (Exception)
            {
                StregsystemUi.DisplayGeneralError("Input was invalid");
            }
        }
        private void DisplayUserInfo(string username)
        {
            try
            {
                User user = Stregsystem.GetUserByUsername(username);

                StregsystemUi.DisplayUserInfo(user);
            }
            catch (UserDoesNotExistException)
            {
                StregsystemUi.DisplayGeneralError("The user does not exist");
            }
        }
        private void SetProductActive(string[] command)
        {
            // TODO: Add try catch om alle parses
            int id = int.Parse(command[1]);
            Product product = Stregsystem.GetProductByID(id);
            if (product.GetType() == typeof(SeasonalProduct))
            {
                throw new SeasonalProductException("Cannot change active state of a seasonal product");
            }
            product.Active = true;
        }

        private void SetProductInactive(string[] command)
        {
            int id = int.Parse(command[1]);
            Product product = Stregsystem.GetProductByID(id);
            if (product.GetType() == typeof(SeasonalProduct))
            {
                throw new SeasonalProductException("Cannot change active state of a seasonal product");
            }
            product.Active = false;
        }
        private void SetProductCreditOn(string[] command)
        {
            int id = int.Parse(command[1]);
            Product product = Stregsystem.GetProductByID(id);
            
            product.CanBeBoughtOnCredit = true;
        }
        private void SetProductCreditOff(string[] command)
        {
            int id = int.Parse(command[1]);
            Product product = Stregsystem.GetProductByID(id);
            
            product.CanBeBoughtOnCredit = false;
        }

        private void AddCreditsToUser(string[] command)
        {
            User user = null;
            decimal amount = 0m;
            try
            {
                user = Stregsystem.GetUserByUsername(command[1]);
                amount = decimal.Parse(command[2]);
                Stregsystem.AddCreditsToAccount(user, amount);
            }
            catch (UserDoesNotExistException)
            {
                StregsystemUi.DisplayGeneralError("User does not exist");
            }
            catch (Exception)
            {
                StregsystemUi.DisplayGeneralError("ID failed to parse");
            }
            
        }
        

       



    }
}
