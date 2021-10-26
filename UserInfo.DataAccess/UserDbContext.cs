using Microsoft.EntityFrameworkCore;
using UserInfo.Entities.Model;
//using UserInfo.Entities.Model;

namespace UserInfo.DataAccess
{
    public class UserDbContext : DbContext
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost ; Database=UserDb; uid=sa  ; pwd=a123456!");
        }
        public UserDbContext()
        {
        }*/
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {
           // options.Database.EnsureCreated();
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Seed();
        }
      
        //public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Geolocation> Geolocations { get; set; }


    }
}
