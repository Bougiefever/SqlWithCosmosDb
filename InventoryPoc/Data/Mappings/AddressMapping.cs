using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models;

namespace InventoryPoc.Data.Mappings
{
  public class AddressMapping : EntityTypeConfiguration<Address>
  {
    public AddressMapping()
    {
      ToTable("Address");
      HasKey<int>(x => x.Id);
    }
  }
}