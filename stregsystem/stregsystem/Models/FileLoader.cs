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
        public void StripTagsRegex()
        {
            foreach (string line in lines)
            {
                Regex.Replace(line, "<[^>]*>", "");
            }
        }

        // TODO: Remove Func from this scope
        //public void WriteFileToconsole()
        //{
        //    foreach (string line in lines)
        //    {
        //        Console.WriteLine(line);
        //    }
        //}
    }
}
