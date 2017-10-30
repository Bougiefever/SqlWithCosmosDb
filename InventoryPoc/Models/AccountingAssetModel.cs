using InventoryPoc.Data.Enums;

namespace InventoryPoc.Models
{
  public class AccountingAssetModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public InventoryAssetType InventoryAssetType { get; set; }
    public decimal OriginalCost { get; set; }
    public int BookNumber { get; set; }
    public DepreciationMethod DepreciationMethod { get; set; }
    public decimal DepreciationBasis { get; set; }
  }
}