using System.Data.Entity;
using Travel.Data.Entities;

namespace Travel.Data.ConcreteEF
{
        public class TravelContext : DbContext
        {
            public TravelContext()
                : base("name=TravelContext")
            { }


           /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                throw new UnintentionalCodeFirstException();
            }*/

            public DbSet<User> Users { get; set; }
            public DbSet<UserCredentials> UserCredentials { get; set; }
            public DbSet<City> Cities { get; set; }
            public DbSet<Photo> Photos { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public DbSet<Visiting> Visiting { get; set; }
    }
}
