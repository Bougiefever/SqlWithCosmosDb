using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class EmployeeMapping : EntityTypeConfiguration<Employee>
  {
    public EmployeeMapping()
    {
      ToTable("Employee");
      HasKey(x => x.Id);
      HasMany(x => x.Contracts).WithOptional(x => x.ProjectManager).HasForeignKey(x => x.ProjectManagerId);
      HasRequired(x => x.Role).WithMany(x => x.Employees).HasForeignKey(x => x.DefaultRoleId);
      HasMany(x => x.GroupUsers).WithOptional(x => x.Employee).HasForeignKey(x => x.EmployeeId);
    }
  }
}