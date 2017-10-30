using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class ClientContactMapping : EntityTypeConfiguration<ClientContact>
  {
    public ClientContactMapping()
    {
      ToTable("ClientContract");
      HasKey((x => x.Id));
      HasMany(x => x.Deliverables).WithRequired(x => x.Recipient).HasForeignKey(x => x.RecipientId);
    }
  }
}