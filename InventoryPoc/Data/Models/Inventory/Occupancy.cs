using System.ComponentModel.DataAnnotations;
using InventoryPoc.Data.Enums;
using Newtonsoft.Json;

namespace InventoryPoc.Data.Models.Inventory
{
  public class Occupancy
  {
    [JsonProperty(PropertyName = "code")]
    public OccupancyCode OccupancyCode { get; set; }

    [JsonProperty(PropertyName = "percent")]
    public double OccupancyPercent { get; set; }
  }
}