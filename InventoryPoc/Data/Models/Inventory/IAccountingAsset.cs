using System;
using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Inventory
{
  public interface IAccountingAsset : IEntity
  {
    AccountingAssetStatus AccountingAssetStatus { get; set; }
    decimal DepreciationBasis { get; set; }
    DateTime? DepreciationBeginDate { get; set; }
    int UsefulLifeYear { get; set; }
    int UsefulLifeMonths { get; set; }
    decimal DepreciationPeriod { get; set; }
    decimal DepreciationYearToDate { get; set; }
    decimal DepreciationAccumulated { get; set; }
    decimal DepreciationAnnualProvision { get; set; }
    decimal DepreciationProjectedProvision { get; set; }
    decimal DepreciationProvision { get; set; }
    int InventoryAssetId { get; set; }
    InventoryAsset InventoryAsset { get; set; }
    int AccountingHeaderId { get; set; }
    AccountingHeader AccountingHeader { get; set; }
  }
}