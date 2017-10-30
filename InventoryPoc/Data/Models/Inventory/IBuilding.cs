using System.Collections;
using System.Collections.Generic;
using InventoryPoc.Data.Enums;
using Newtonsoft.Json;

namespace InventoryPoc.Data.Models.Inventory
{
  public interface IBuilding : IDocEntity
  {
    [JsonProperty(PropertyName = "address")]
    Address Address { get; set; }

    [JsonProperty(PropertyName = "buildingstatus")]
    BuildingStatus BuildingStatus { get; set; }

    [JsonProperty(PropertyName = "buildingname")]
    string BuildingName { get; set; }

    [JsonProperty(PropertyName = "buildingnumber")]
    string BuildingNumber { get; set; }

    [JsonProperty(PropertyName = "yearbuilt")]
    int YearBuilt { get; set; }

    [JsonProperty(PropertyName = "buildingenvironmentfactors")]
    BuildingEnvironmentFactors BuildingEnvironmentFactors { get; set; }

    [JsonProperty(PropertyName = "floodzonecertificationnumber")]
    string FloodZoneCertificationNumber { get; set; }

    [JsonProperty(PropertyName = "latitude")]
    decimal Latitude { get; set; }

    [JsonProperty(PropertyName = "longitude")]
    decimal Longitude { get; set; }

    [JsonProperty(PropertyName = "occupancycodes")]
    Occupancy[] OccupancyList { get; set; }

    [JsonProperty(PropertyName = "customDataList")]
    CustomData[] CustomDataList { get; set; }

    [JsonProperty(PropertyName = "freeformData")]
    dynamic FreeformData { get; set; }
  }
}