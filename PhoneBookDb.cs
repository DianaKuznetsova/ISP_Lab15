using Microsoft.EntityFrameworkCore;

namespace ISP_Lab15
{
    class PhoneBookDb : DbContext
    {

        public PhoneBookDb() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PhoneNumber> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PhoneBookDb;Trusted_Connection=True;");
        }
    }
}
