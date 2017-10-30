using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Profile
{
  public class ProcessingInstruction : IEntity
  {
    public int Id { get; set; }
    public string SpecialInstructions { get; set; }
    public ProcessingInstructionType ProcessingInstructionType { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
  }
}