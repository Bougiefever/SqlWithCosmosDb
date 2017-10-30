using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class ScheduledItemMapping : EntityTypeConfiguration<ScheduledItem>
  {
    public ScheduledItemMapping()
    {
      HasKey(x => x.Id);
      ToTable("ScheduledItem");
    }
  }
}