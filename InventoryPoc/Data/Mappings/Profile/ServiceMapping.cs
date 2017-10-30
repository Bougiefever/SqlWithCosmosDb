using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
    public class ServiceMapping : EntityTypeConfiguration<Service>
    {
        public ServiceMapping()
        {
            ToTable("Service");
            HasKey(x => x.Id);
        }
    }
}