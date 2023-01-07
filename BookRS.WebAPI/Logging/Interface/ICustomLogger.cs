using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRS.WebAPI.Logging.Interface
{
    public interface ICustomLogger
    {
        public void Log( string content,string type= "");
      
    }
}
