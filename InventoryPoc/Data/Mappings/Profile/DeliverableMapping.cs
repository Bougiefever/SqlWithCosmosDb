using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class DeliverableMapping : EntityTypeConfiguration<Deliverable>
  {
    public DeliverableMapping()
    {
      ToTable("Deliverable");
      HasKey(x => x.Id);
    }
  }
}