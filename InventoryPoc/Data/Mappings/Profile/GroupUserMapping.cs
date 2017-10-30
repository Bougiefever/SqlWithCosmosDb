using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class GroupUserMapping : EntityTypeConfiguration<GroupUser>
  {
    public GroupUserMapping()
    {
      ToTable("GroupUser");
      HasKey(x => x.Id);
      //HasRequired(x => x.Employee).WithMany(x => x.GroupUsers).HasForeignKey(x => x.EmployeeId);
      //HasRequired(x => x.Group).WithMany(x => x.GroupUsers).HasForeignKey(x => x.GroupId);
      //HasRequired(x => x.Role).WithMany(x => x.GroupUsers).HasForeignKey(x => x.RoleId);
    }
  }
}