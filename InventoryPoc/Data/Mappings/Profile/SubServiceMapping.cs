using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
    public class SubServiceMapping : EntityTypeConfiguration<SubService>
    {
        public SubServiceMapping()
        {
            ToTable("SubService");
            HasKey(x => x.Id);
        }
    }
}