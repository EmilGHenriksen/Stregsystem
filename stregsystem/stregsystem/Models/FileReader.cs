using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace stregsystem.Models
{
    public class FileReader
    {
        string[] productsFile = File.ReadAllLines("products" + ".csv");
        string[] usersFile = File.ReadAllLines("users" + ".csv");

        // Id;name;price;active;deactivate_date
        // Dividing by 100 because the value in the file is measured in Oere not in DKK
        public List<Product> GenerateProductsList()
        {
            List<Product> products = new List<Product>();
            bool IsActive;
            char delimiter = ';';
            int dataRowStart = 1;

            RemoveProperties();
            for (int i = dataRowStart; i < productsFile.Length; i++)
            {
                string[] data = productsFile[i].Split(delimiter);
                IsActive = IntToBool(int.Parse(data[3]));
                products.Add(new Product(int.Parse(data[0]), data[1], (decimal.Parse(data[2])/100), IsActive, false));
            }
            return products;
        }

        // id,firstname,lastname,username,balance,email
        // Dividing by 100 because the value in the file is measured in Oere not in DKK
        public List<User> GenerateUsersList()
        {
            List<User> users = new List<User>();
            char delimiter = ',';
            int dataRowStart = 1;

            RemoveProperties();
            for (int i = dataRowStart; i < usersFile.Length; i++)
            {
                string[] data = usersFile[i].Split(delimiter);
                users.Add(new User(data[1], data[2], data[3], (decimal.Parse(data[4])/100), data[5]));
            }
            return users;
        }

        private bool IntToBool(int input)
        {
            bool output;
            if (input == 0)
            {
                output = false;
            }
            else
                output = true;
            return output;
        }

        private void RemoveProperties()
        {
            for (int i = 0; i < productsFile.Length; i++)
            {
                productsFile[i] = Regex.Replace(productsFile[i], "<[^>]*>", "");
                productsFile[i] = productsFile[i].Replace("\"", "");
            }
        }
    }
}
