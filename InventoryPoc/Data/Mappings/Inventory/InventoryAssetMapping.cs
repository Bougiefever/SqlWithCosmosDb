using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Inventory;

namespace InventoryPoc.Data.Mappings.Inventory
{
  public class InventoryAssetMapping : EntityTypeConfiguration<InventoryAsset>
  {
    public InventoryAssetMapping()
    {
      ToTable("InventoryAsset");
      HasKey(x => x.Id);
      //Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
      Property(x => x.AcquisitionDate).IsOptional();
      Property(x => x.CostReplacementNew).HasPrecision(18, 2);
      Property(x => x.OriginalCost).HasPrecision(18, 2);
      HasOptional(x => x.InsuranceAsset).WithRequired(x => x.InventoryAsset);
      HasMany(x => x.AccountingAssets).WithRequired(x => x.InventoryAsset).HasForeignKey(x => x.InventoryAssetId);
    }
  }
}