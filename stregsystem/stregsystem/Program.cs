using System;
using stregsystem.Interfaces;
using stregsystem.Models;

namespace stregsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLoader fileloader = new FileLoader();
            fileloader.StripTagsRegex();
            //DateTime now = DateTime.Now;
            //User user = new User("Emil", "Henriksen", "H", "Em@il.dk");
            //InsertCashTransaction insert = new InsertCashTransaction(user, 1, 311, now);
            //Console.WriteLine(insert.ToString());
        }
    }
}
