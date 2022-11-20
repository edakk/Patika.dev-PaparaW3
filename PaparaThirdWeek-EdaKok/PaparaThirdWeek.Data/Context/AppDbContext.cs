using Microsoft.EntityFrameworkCore;
using PaparaThirdWeek.Data.Configurations;
using PaparaThirdWeek.Domain.Entities;


namespace PaparaThirdWeek.Data.Context
{
  public  class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
   
    }
}
