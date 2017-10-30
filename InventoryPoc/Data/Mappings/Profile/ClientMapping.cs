using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class ClientMapping : EntityTypeConfiguration<Client>
  {
    public ClientMapping()
    {
      ToTable("Client");
      HasKey<int>(x => x.Id);
      HasOptional<Address>(x => x.Address);
      Property(x => x.SalesForceAccountId).IsOptional();
      this.HasMany(x => x.Contracts).WithRequired(x => x.Client).HasForeignKey(x => x.ClientId);
    }
  }
}