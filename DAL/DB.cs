using System.Data.Entity;
using Model;
using FilmSiteAdministration.Model;
using FilmSiteAdministration.DAL;

namespace DAL
{
    public class DB : DbContext
    {
        public DB(bool shouldSeed = false)
            : base("name=Filmsite")
        {
            Database.CreateIfNotExists();

            if (shouldSeed)
            {
                Database.SetInitializer<DB>(new DBSeeder());
            }
        }

        public DbSet<AdminUserModelDAL> AdminUsers { get; set; }
        public DbSet<MovieModelDAL> Movies { get; set; }
        public DbSet<MovieOrderModelDAL> MovieOrders { get; set; }
        public DbSet<CustomerModelDAL> Customers { get; set; }
        public DbSet<LoggTypeDAL> Logs { get; set; }
        public DbSet<FAQModelDAL> FAQs { get; set; }
    }
}
