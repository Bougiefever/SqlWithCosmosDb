using InventoryPoc.Data.Enums;
using Newtonsoft.Json;

namespace InventoryPoc.Data.Models.Inventory
{
  public interface IDocEntity
  {
    [JsonProperty(PropertyName = "id")]
    string Id { get; set; }

    [JsonProperty(PropertyName = "groupid")]
    string GroupId { get; set; }

    [JsonProperty(PropertyName = "assettype")]
    InventoryAssetType InventoryAssetType { get; set; }

    [JsonProperty("name")]
    string Name { get; set; }
  }
}