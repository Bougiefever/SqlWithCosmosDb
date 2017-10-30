using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Inventory;

namespace InventoryPoc.Data.Mappings.Inventory
{
  public class AccountingHeaderMapping : EntityTypeConfiguration<AccountingHeader>
  {
    public AccountingHeaderMapping()
    {
      ToTable("AccountingHeader");
      HasKey(x => x.Id);
      //Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
      Property(x => x.DepreciationConvention).HasMaxLength(50);
      HasMany(x => x.AccountingAssets)
        .WithRequired(x => x.AccountingHeader).HasForeignKey(x => x.AccountingHeaderId);
    }
  }
}