using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace stregsystem.Models
{
    class FileLoader
    {
        string[] lines = File.ReadAllLines("products" + ".csv");
        char delimiter = ';';
        int dataRowStart = 1;

        // Id;name;price;active;deactivate_date
        public List<Product> GenerateProducts()
        {
            List<Product> products = new List<Product>();
            bool IsActive;
            RemoveProperties();
            for (int i = dataRowStart; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(delimiter);
                IsActive = IntToBool(int.Parse(data[3]));
                products.Add(new Product(int.Parse(data[0]), data[1], decimal.Parse(data[2]), IsActive, false));
            }
            return products;
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
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = Regex.Replace(lines[i], "<[^>]*>", "");
                lines[i] = lines[i].Replace("\"", "");
            }
        }
    }
}
