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
                    BuyProduct(splitCommand);
                    break;
                case 3:
                    BuyMultipleProducts(splitCommand);
                    break;
                default:
                    StregsystemUi.DisplayTooManyArgumentsError(command);
                    break;
            }
        }
        
        private void BuyMultipleProducts(string[] command)
        {
            try
            {
                User user = Stregsystem.GetUserByUsername(command[0]);
                int count = int.Parse(command[1]);
                Product product = Stregsystem.GetProductByID(int.Parse(command[2]));
                BuyTransaction buyTransaction = null;
                if (user.Balance < (count*product.Price))
                {
                    StregsystemUi.DisplayInsufficientCash(user, product, count);
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        buyTransaction = Stregsystem.BuyProduct(user, product);
                    }
                    StregsystemUi.DisplayUserBuysProduct(count, buyTransaction);
                }
            }
            catch (ProductDoesNotExistException)
            {
                StregsystemUi.DisplayProductNotFound(command[2]);
            }
            catch (UserDoesNotExistException)
            {
                StregsystemUi.DisplayUserNotFound(command[0]);
            }
            catch (ProductNotActiveException)
            {
                StregsystemUi.DisplayGeneralError("Product is not active");
            }
            catch (InsufficientCreditsException)
            {
                StregsystemUi.DisplayGeneralError("Insufficient Credits");
            }
            catch (Exception)
            {
                StregsystemUi.DisplayGeneralError("Input was invalid");
            }
        }
        
        private void BuyProduct(string[] command)
        {
            try
            {
                User user = Stregsystem.GetUserByUsername(command[0]);
                Product product = Stregsystem.GetProductByID(int.Parse(command[1]));
                BuyTransaction buyTransaction = Stregsystem.BuyProduct(user, product);
                StregsystemUi.DisplayUserBuysProduct(buyTransaction);
            }
            catch (ProductDoesNotExistException)
            {
                StregsystemUi.DisplayProductNotFound(command[1]);
            }
            catch (UserDoesNotExistException)
            {
                StregsystemUi.DisplayUserNotFound(command[0]);
            }
            catch (ProductNotActiveException)
            {
                StregsystemUi.DisplayGeneralError("Product is not active");
            }
            catch (InsufficientCreditsException)
            {
                StregsystemUi.DisplayGeneralError("Insufficient Credits");
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
            try
            {
                int id = int.Parse(command[1]);
                Product product = Stregsystem.GetProductByID(id);
                if (product.GetType() == typeof(SeasonalProduct))
                {
                    throw new SeasonalProductException("Cannot change active state of a seasonal product");
                }
                product.Active = true;
            }
            catch (SeasonalProductException)
            {
                StregsystemUi.DisplayGeneralError("Unable to change active state on a seasonal product");
            }
            catch (Exception)
            {
                StregsystemUi.DisplayGeneralError("Invalid input");
            }
        }

        private void SetProductInactive(string[] command)
        {
            try
            {
                int id = int.Parse(command[1]);
                Product product = Stregsystem.GetProductByID(id);
                if (product.GetType() == typeof(SeasonalProduct))
                {
                    throw new SeasonalProductException("Cannot change active state of a seasonal product");
                }
                product.Active = false;
            }
            catch (SeasonalProductException)
            {
                StregsystemUi.DisplayGeneralError("Unable to change active state on a seasonal product");
            }
            catch (Exception)
            {
                StregsystemUi.DisplayGeneralError("Invalid input");
            }
        }
        private void SetProductCreditOn(string[] command)
        {
            try
            {
                int id = int.Parse(command[1]);
                Product product = Stregsystem.GetProductByID(id);
                product.CanBeBoughtOnCredit = true;
            }
            catch (ProductDoesNotExistException)
            {
                StregsystemUi.DisplayGeneralError("The product does not exist");
            }
            catch (Exception)
            {
                StregsystemUi.DisplayGeneralError("Invalid input");
            }
        }
        private void SetProductCreditOff(string[] command)
        {
            try
            {
                int id = int.Parse(command[1]);
                Product product = Stregsystem.GetProductByID(id);
                product.CanBeBoughtOnCredit = false;
            }
            catch (ProductDoesNotExistException)
            {
                StregsystemUi.DisplayGeneralError("The product does not exist");
            }
            catch (Exception)
            {
                StregsystemUi.DisplayGeneralError("Invalid input");
            }
        }

        private void AddCreditsToUser(string[] command)
        {
            try
            {
                User user = null;
                decimal amount = 0m;
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
