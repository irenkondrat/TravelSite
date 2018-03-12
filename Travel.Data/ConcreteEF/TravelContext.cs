using System.Data.Entity;
using Kondrat.PracticeTask.Travel.Data.Entities;

namespace Kondrat.PracticeTask.Travel.Data.ConcreteEF
{
        public class TravelContext : DbContext
        {
            public TravelContext()
                : base("name=TravelContext")
            { }

            public DbSet<User> Users { get; set; }
            public DbSet<UserCredentials> UserCredentials { get; set; }
            public DbSet<City> Cities { get; set; }
            public DbSet<Photo> Photos { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public DbSet<Visiting> Visiting { get; set; }
    }
}
