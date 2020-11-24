using System;
using System.Collections.Generic;
using stregsystem.Interfaces;
using stregsystem.Models;

namespace stregsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoader fileloader = new FileLoader();
            List<Product> testList = fileloader.GenerateProducts();

            foreach (Product item in testList)
            {
                Console.WriteLine(item);
            }
            //DateTime now = DateTime.Now;
            //User user = new User("Emil", "Henriksen", "H", "Em@il.dk");
            //InsertCashTransaction insert = new InsertCashTransaction(user, 1, 311, now);
            //Console.WriteLine(insert.ToString());
        }
    }
}
