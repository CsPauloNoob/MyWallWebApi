using Microsoft.EntityFrameworkCore;
using MyWallWebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyWallWebApi.Domains.Models;

namespace MyWallWebApi.Insfrastructure.Data.Contexts
{
    public class SqliteContext : IdentityDbContext<ApplicationUser>
    {
        #pragma warning disable CS8618
        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        {

        }



        public DbSet<Post> Post { get; set; }

        public DbSet<ApplicationUser> User { get; set; }

        public DbSet<ApplicationRole> Role { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(k => k.Id);

            modelBuilder.Entity<Post>();
        }
    }

}
