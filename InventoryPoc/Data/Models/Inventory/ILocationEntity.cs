using InventoryPoc.Data.Enums;
using Newtonsoft.Json;

namespace InventoryPoc.Data.Models.Inventory
{
  public interface ILocationEntity : IDocEntity
  {
    [JsonProperty(PropertyName = "locationtype")]
    LocationType LocationType { get; set; }

    [JsonProperty(PropertyName = "locationname")]
    string LocationName { get; set; }
  }
}