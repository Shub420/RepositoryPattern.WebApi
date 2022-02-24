using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Log
    {
        public int Id { get; set; }
        public string ExpMessage { get; set; }
        public string ExpType { get; set; }
        public string ExpSource { get; set; }
        public string ExpUrl { get; set; }
        public DateTime LogDate { get; set; }
    }
}
