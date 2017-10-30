using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Inventory
{
  public class Location : ILocationEntity
  {
    public string Id { get; set; }
    public string GroupId { get; set; }
    public InventoryAssetType InventoryAssetType { get; set; }
    public string Name { get; set; }
    public LocationType LocationType { get; set; }
    public string LocationName { get; set; }
  }
}