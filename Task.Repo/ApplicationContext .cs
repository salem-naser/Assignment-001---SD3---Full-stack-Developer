using System;
using Microsoft.EntityFrameworkCore;
using Task.Domain;
namespace Task.Repo
{
    public class ApplicationContext : DbContext
    {
      
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
            new UserAdressMap(modelBuilder.Entity<Adress>());
        }
    }
}
