using InventoryPoc.Data.Models.Profile;
using System.Data.Entity.ModelConfiguration;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class OpportunityMapping : EntityTypeConfiguration<Opportunity>
  {
    public OpportunityMapping()
    {
      ToTable("Opportunity");
      HasKey<int>(x => x.Id);
    }
  }
}