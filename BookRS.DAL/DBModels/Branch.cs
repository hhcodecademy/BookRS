using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRS.DAL.DBModels
{
   public class Branch:BaseEntity
    {
        public int StoreId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

    }
}
