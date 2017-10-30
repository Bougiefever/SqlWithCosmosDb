using System;
using System.Collections.Generic;
using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Inventory
{
  public class InventoryAsset : IInventoryAsset
  {
    public int Id { get; set; }
    public InventoryAssetType InventoryAssetType { get; set; }
    public DateTime? AcquisitionDate { get; set; }
    public decimal OriginalCost { get; set; }
    public decimal CostReplacementNew { get; set; }
    public int InventoryEntityId { get; set; }
    public virtual InventoryEntity InventoryEntity { get; set; }
    public virtual InsuranceAsset InsuranceAsset { get; set; }
    public virtual ICollection<AccountingAsset> AccountingAssets { get; set; }
  }
}