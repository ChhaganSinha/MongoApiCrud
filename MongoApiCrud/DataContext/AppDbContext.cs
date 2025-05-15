using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using MongoApiCrud.Models;

namespace MongoApiCrud.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Planet> Planets { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Planet>().ToCollection("planets");
        }

        public static AppDbContext Create(IMongoDatabase db)
        {
            return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseMongoDB(db.Client, db.DatabaseNamespace.DatabaseName)
                .Options);
        }
    }
}
