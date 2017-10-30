using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class DeliverableRecipientMapping : EntityTypeConfiguration<DeliverableRecipient>
  {
    public DeliverableRecipientMapping()
    {
      ToTable("DeliverableRecipient");
      HasKey(x => x.Id);
    }
  }
}