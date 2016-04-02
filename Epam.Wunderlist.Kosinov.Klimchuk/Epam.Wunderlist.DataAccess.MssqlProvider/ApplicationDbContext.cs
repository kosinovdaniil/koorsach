using Epam.Wunderlist.DataAccess.MssqlProvider.ModelsConfiguration;
using Epam.Wunderlist.DomainModel;
using System.Data.Entity;

namespace Epam.Wunderlist.DataAccess.MssqlProvider
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=GoalsDatabase")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Amplifier> Amplifiers { get; set; }
        public virtual DbSet<BassGuitar> BassGuitars { get; set; }
        public virtual DbSet<Cymbal> Cymbals { get; set; }
        public virtual DbSet<Drum> Drums { get; set; }
        public virtual DbSet<Guitar> Guitars { get; set; }
        public virtual DbSet<Keys> Keys { get; set; }
        public virtual DbSet<Microphone> Microphones { get; set; }
        public virtual DbSet<Strings> Strings { get; set; }
        public virtual DbSet<Trumpet> Trumpets { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
        }
    }
}
