using System;
using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Inventory
{
  public class AccountingAsset : IAccountingAsset
  {
    public int Id { get; set; }
    public AccountingAssetStatus AccountingAssetStatus { get; set; }
    public decimal DepreciationBasis { get; set; }
    public DateTime? DepreciationBeginDate { get; set; }
    public int UsefulLifeYear { get; set; }
    public int UsefulLifeMonths { get; set; }
    public decimal DepreciationPeriod { get; set; }
    public decimal DepreciationYearToDate { get; set; }
    public decimal DepreciationAccumulated { get; set; }
    public decimal DepreciationAnnualProvision { get; set; }
    public decimal DepreciationProjectedProvision { get; set; }
    public decimal DepreciationProvision { get; set; }
    public int InventoryAssetId { get; set; }
    public virtual InventoryAsset InventoryAsset { get; set; }
    public int AccountingHeaderId { get; set; }
    public virtual AccountingHeader AccountingHeader { get; set; }
  }
}