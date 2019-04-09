using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoggTypeDAL
    {
        [Key]
        public Guid LogID { get; set; }
        public string EventType { get; set; }
        public string Created_By { get; set; }
        public string LogMessage { get; set; }
        public DateTime Created_date { get; set; }
    }
}
