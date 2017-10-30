using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Inventory;

namespace InventoryPoc.Data.Mappings.Inventory
{
  public class InsuranceAssetMapping : EntityTypeConfiguration<InsuranceAsset>
  {
    public InsuranceAssetMapping()
    {
      ToTable("InsuranceAsset");
      HasKey(x => x.Id);
      //Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
      Property(x => x.AcquisitionDate).IsOptional();
      Property(x => x.DateOfInspection).IsOptional();
      Property(x => x.TrendDate).IsOptional();
      Property(x => x.TotalCostOfReplacement).HasPrecision(18, 2);
    }
  }
}