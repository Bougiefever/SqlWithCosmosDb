using System;
using InventoryPoc.Data.Enums;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Models.Inventory
{
  public class InsuranceAsset : IInsuranceAsset
  {
    public int Id { get; set; }
    public InsuranceAssetStatus InsuranceAssetStatus { get; set; }
    public DateTime? AcquisitionDate { get; set; }
    public DateTime? TrendDate { get; set; }
    public decimal TotalCostOfReplacement { get; set; }
    public DateTime? DateOfInspection { get; set; }
    public double ExclusionPercent { get; set; }
    public int InventoryAssetId { get; set; }
    public virtual InventoryAsset InventoryAsset { get; set; }
    public int MemberId { get; set; }
    public virtual Member Member { get; set; }
  }
}