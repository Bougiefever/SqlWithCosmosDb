using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
    public class IndustryMapping : EntityTypeConfiguration<Industry>
    {
        public IndustryMapping()
        {
            ToTable("Industry");
            HasKey(x => x.Id);
        }
    }
}