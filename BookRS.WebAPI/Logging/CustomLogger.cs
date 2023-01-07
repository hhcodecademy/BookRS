using BookRS.WebAPI.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRS.WebAPI.Logging
{
    public class CustomLogger : ICustomLogger
    {
        public void Log(string content, string type = "")

        {
            if (type == "error")
            {
                
                Console.WriteLine("ERROR- " + content);
              
            }
            else if (type == "warning")
            {
               
                Console.WriteLine("WARNING- " + content);
               
            }
            else
            {
                Console.WriteLine("DEFAULT- " + content);
            }
        }


  
    }


    
}
