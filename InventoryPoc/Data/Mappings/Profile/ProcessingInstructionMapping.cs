using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class ProcessingInstructionMapping : EntityTypeConfiguration<ProcessingInstruction>
  {
    public ProcessingInstructionMapping()
    {
      ToTable("ProcessingInstruction");
      HasKey(x => x.Id);
    }
  }
}