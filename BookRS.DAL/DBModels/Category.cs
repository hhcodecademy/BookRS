using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRS.DAL.DBModels
{
    public class Category:BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
    }
}
