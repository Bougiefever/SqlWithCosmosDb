using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Inventory
{
  public class Building : IBuilding
  {
    public string Id { get; set; }
    public string GroupId { get; set; }

    [DisplayName("Asset Type")]
    public InventoryAssetType InventoryAssetType { get; set; }

    public string Name { get; set; }
    public Address Address { get; set; }

    [DisplayName("Status")]
    public BuildingStatus BuildingStatus { get; set; }

    public string BuildingNumber { get; set; }
    public int YearBuilt { get; set; }

    [DisplayName("Options")]
    public BuildingEnvironmentFactors BuildingEnvironmentFactors { get; set; }

    [DisplayName("Flood Zone Cert#")]
    public string FloodZoneCertificationNumber { get; set; }

    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public string BuildingName { get; set; }

    [DisplayName("Occupancy Codes")]
    [UIHint("Occupancy")]
    public Occupancy[] OccupancyList { get; set; }

    [DisplayName("Custom Data")]
    [UIHint("CustomData")]
    public CustomData[] CustomDataList { get; set; }

    public dynamic FreeformData { get; set; }
  }
}