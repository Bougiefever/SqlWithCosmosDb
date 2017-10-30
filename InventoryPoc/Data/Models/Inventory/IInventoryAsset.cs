using System;
using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Inventory
{
  public interface IInventoryAsset : IEntity
  {
    InventoryAssetType InventoryAssetType { get; set; }
    DateTime? AcquisitionDate { get; set; }
    decimal OriginalCost { get; set; }
    decimal CostReplacementNew { get; set; }
    int InventoryEntityId { get; set; }
    InventoryEntity InventoryEntity { get; set; }
    InsuranceAsset InsuranceAsset { get; set; }
  }
}