using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSiteAdministration.Model
{
    public class AdminUserModelDAL
    {
        [Key]
        public string Username { get; set; }
        public byte[] HashedPassword { get; set; }
    }
}
