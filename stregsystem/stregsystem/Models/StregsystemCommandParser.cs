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

            stregsystemUi.CommandEntered += ParseCommand;
        }
        private IStregsystem Stregsystem { get; }
        private IStregsystemUi StregsystemUi { get; }

        private void GenerateAdminCommands()
        {
            adminCommands.Add(":q", x => StregsystemUi.Close());
            adminCommands.Add(":quit", x => StregsystemUi.Close());
            adminCommands.Add(":activate", x => );
        }
        private void ParseCommand(string input)
        {
            throw new NotImplementedException();
        }

       



    }
}
