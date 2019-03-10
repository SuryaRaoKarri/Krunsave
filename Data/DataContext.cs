using Krunsave.Model;
using Microsoft.EntityFrameworkCore;

namespace Krunsave.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Availablefood> Availablefoods {get; set;}
        public DbSet<Foodtag> Foodtags {get; set;}

        public DbSet<Availablefoodtag> availablefoodtags {get; set;}
        public DbSet<Foodtype> Foodtypes {get; set;}
        public DbSet<Role> Roles {get; set;}
        public DbSet<Store> Stores {get; set;}
        public  DbSet<Storetype> Storetypes { get; internal set; }
        public DbSet<User> Users {get; set;}
        public DbSet<Userview> Userviews{get; set;}
        
        //public object Store { get; internal set; }
        //public object Storetypes { get; internal set; }

        // public DbSet<AvailablefoodFoodtag> AvailablefoodFoodtags {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Availablefoodtag>()
        .HasKey(a => new{a.foodTagID, a.availableFoodID});
    }
        
    }
}