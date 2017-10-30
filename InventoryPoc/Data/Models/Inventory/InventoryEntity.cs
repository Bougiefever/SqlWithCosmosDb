using InventoryPoc.Data.Enums;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Models.Inventory
{
  public class InventoryEntity : IEntity
  {
    public int Id { get; set; }
    public InventoryEntityType InventoryEntityType { get; set; }
    public InventoryEntityStatus InventoryEntityStatus { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CustomDataId { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
    public virtual InventoryAsset InventoryAsset { get; set; }
  }
}