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
            FileReader fileHandler = new FileReader();
            IStregsystem stregsystem = new Stregsystem(fileHandler);
            IStregsystemUi ui = new StregsystemCLI(stregsystem);
            StregsystemCommandParser commandParser = new StregsystemCommandParser(stregsystem, ui);
            ui.Start();
        }
    }
}
