using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRS.DAL.DBModels
{
    public class Company:BaseEntity
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }
}
