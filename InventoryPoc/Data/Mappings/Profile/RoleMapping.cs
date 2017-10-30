using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class RoleMapping : EntityTypeConfiguration<Role>
  {
    public RoleMapping()
    {
      ToTable("Role");
      HasKey(x => x.Id);
      HasMany(x => x.GroupUsers).WithOptional(x => x.Role).HasForeignKey(x => x.RoleId);
    }
  }
}