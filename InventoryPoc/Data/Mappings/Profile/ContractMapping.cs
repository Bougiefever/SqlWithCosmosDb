using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Security.Cryptography.X509Certificates;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class ContractMapping : EntityTypeConfiguration<Contract>
  {
    public ContractMapping()
    {
      ToTable("Contract");
      HasKey<int>(x => x.Id);
      Property(x => x.ProjectCode).IsOptional();
      Property(x => x.ContractName).HasMaxLength(100);
      HasRequired(x => x.Client);
      HasMany(x => x.Groups).WithRequired(x => x.Contract).HasForeignKey(x => x.ContractId);
      //HasMany<Employee>(s => s.Employees)
      //    .WithMany(c => c.Contracts)
      //    .Map(cs =>
      //         {
      //             cs.MapLeftKey("ContractId");
      //             cs.MapRightKey("EmployeeId");
      //             cs.ToTable("ContractEmployee");
      //         });
    }
  }
}