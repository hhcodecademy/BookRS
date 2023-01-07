using BookRS.WebAPI.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRS.WebAPI.Logging
{
    public class CustomLoggerV2 : ICustomLogger
    {
      
        public void Log(string content, string type = "")

        {
            if (type == "error")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR- " + content);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (type == "warning")
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("WARNING- " + content);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.WriteLine("DEFAULT- " + content);
            }
        }
    }
}
