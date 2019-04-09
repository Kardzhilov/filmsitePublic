using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class CustomerModelDAL
    {
        [Key]
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<MovieOrderModelDAL> MovieRentals { get; set; }
    }
}
