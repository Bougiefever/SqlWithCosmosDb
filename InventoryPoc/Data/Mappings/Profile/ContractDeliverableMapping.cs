using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class ContractDeliverableMapping : EntityTypeConfiguration<ContractDeliverable>
  {
    public ContractDeliverableMapping()
    {
      ToTable("ContractDeliverable");
      HasKey(x => x.Id);
      HasRequired(x => x.Group).WithMany(x => x.ContractDeliverables).HasForeignKey(x => x.GroupId);
      HasRequired(x => x.Deliverable).WithMany(x => x.ContractDeliverables).HasForeignKey(x => x.DeliverableId);
      HasMany(x => x.Recipients).WithRequired(x => x.ContractDeliverable).HasForeignKey(x => x.DeliverableId);
    }
  }
}