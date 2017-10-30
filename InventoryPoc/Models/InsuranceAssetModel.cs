using InventoryPoc.Data.Enums;

namespace InventoryPoc.Models
{
  public class InsuranceAssetModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public InventoryAssetType InventoryAssetType { get; set; }
    public decimal OriginalCost { get; set; }
    public double ExclusionPercent { get; set; }
    public string MemberName { get; set; }
  }
}