using System.Data.Entity.ModelConfiguration;
using System.Security.Cryptography.X509Certificates;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
    public class SubIndustryMapping : EntityTypeConfiguration<SubIndustry>
    {
        public SubIndustryMapping()
        {
            ToTable("SubIndustry");
            HasKey(x => x.Id);
        }
    }
}