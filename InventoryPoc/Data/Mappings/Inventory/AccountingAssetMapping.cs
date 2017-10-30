using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Inventory;

namespace InventoryPoc.Data.Mappings.Inventory
{
  public class AccountingAssetMapping : EntityTypeConfiguration<AccountingAsset>
  {
    public AccountingAssetMapping()
    {
      ToTable("AccountingAsset");
      HasKey(x => x.Id);
      //Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
      Property(x => x.DepreciationBasis).HasPrecision(18, 2);
      Property(x => x.DepreciationAccumulated).HasPrecision(18, 2);
      Property(x => x.DepreciationAnnualProvision).HasPrecision(18, 2);
      Property(x => x.DepreciationPeriod).HasPrecision(18, 2);
      Property(x => x.DepreciationYearToDate).HasPrecision(18, 2);
      Property(x => x.DepreciationProjectedProvision).HasPrecision(18, 2);
      Property(x => x.DepreciationProvision).HasPrecision(18, 2);
      Property(x => x.DepreciationBeginDate).IsOptional();
    }
  }
}