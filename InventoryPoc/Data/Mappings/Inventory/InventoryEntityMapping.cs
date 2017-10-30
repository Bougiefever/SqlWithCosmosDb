using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Inventory;

namespace InventoryPoc.Data.Mappings.Inventory
{
  public class InventoryEntityMapping : EntityTypeConfiguration<InventoryEntity>
  {
    public InventoryEntityMapping()
    {
      ToTable("InventoryEntity");
      HasKey<int>(x => x.Id);
      //Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
      HasOptional(x => x.InventoryAsset).WithRequired(x => x.InventoryEntity);
    }
  }
}