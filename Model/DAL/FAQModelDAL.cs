using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FAQModelDAL
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool UserSubmitted { get; set; }
        public int Score { get; set; }
    }
}
