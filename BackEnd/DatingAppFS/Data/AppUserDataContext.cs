using DatingAppFS.Entity;
using Microsoft.EntityFrameworkCore;

namespace DatingAppFS.Data
{
    public class AppUserDataContext : DbContext
    {
        public AppUserDataContext(DbContextOptions options) : base(options)
        {
        }

        //type of data to be used as table field in databse <AppUSer>
        //name of database Users
        public DbSet<AppUser> Users { get; set; }
    }
}
