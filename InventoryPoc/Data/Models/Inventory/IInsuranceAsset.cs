using System;
using InventoryPoc.Data.Enums;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Models.Inventory
{
  public interface IInsuranceAsset : IEntity
  {
    InsuranceAssetStatus InsuranceAssetStatus { get; set; }
    DateTime? AcquisitionDate { get; set; }
    DateTime? TrendDate { get; set; }

    decimal TotalCostOfReplacement { get; set; }
    DateTime? DateOfInspection { get; set; }

    double ExclusionPercent { get; set; }
    int InventoryAssetId { get; set; }
    InventoryAsset InventoryAsset { get; set; }
    int MemberId { get; set; }
    Member Member { get; set; }
  }
}