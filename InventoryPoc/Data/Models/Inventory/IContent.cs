using System.Collections.Generic;
using InventoryPoc.Data.Enums;
using Newtonsoft.Json;

namespace InventoryPoc.Data.Models.Inventory
{
  public interface IContent : IDocEntity
  {
    [JsonProperty(PropertyName = "contenttype")]
    ContentType ContentType { get; set; }

    [JsonProperty(PropertyName = "assettag")]
    string AssetTag { get; set; }

    [JsonProperty(PropertyName = "manufacturer")]
    string Manufacturer { get; set; }

    [JsonProperty(PropertyName = "model")]
    string Model { get; set; }

    [JsonProperty(PropertyName = "serialnumber")]
    string SerialNumber { get; set; }

    [JsonProperty(PropertyName = "customDataList")]
    CustomData[] CustomDataList { get; set; }
  }
}