using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Inventory
{
  public class Content : IContent
  {
    public string Id { get; set; }
    public string GroupId { get; set; }
    public InventoryAssetType InventoryAssetType { get; set; }
    public string Name { get; set; }
    public ContentType ContentType { get; set; }
    public string AssetTag { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }

    [UIHint("CustomData")]
    public CustomData[] CustomDataList { get; set; }
  }
}