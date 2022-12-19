using Microsoft.EntityFrameworkCore;
using MyWallWebApi.Models;


namespace MyWallWebApi
{
    public class SqliteContext : DbContext
    {
        #pragma warning disable CS8618
        public SqliteContext(DbContextOptions<SqliteContext> options) : base (options)
        {

        }

        public DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>();
        }
    }

}
