using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaparaThirdWeek.Domain.Entities;


namespace PaparaThirdWeek.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Email).IsRequired();
            //  builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.ToTable("Employees");
        }
    }
}
