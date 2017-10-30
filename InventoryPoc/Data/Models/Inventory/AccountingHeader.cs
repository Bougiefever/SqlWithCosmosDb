using System.Collections.Generic;
using InventoryPoc.Data.Enums;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Models.Inventory
{
  public class AccountingHeader : IEntity
  {
    public int Id { get; set; }
    public int BookNumber { get; set; }
    public DepreciationMethod DepreciationMethod { get; set; }
    public string DepreciationConvention { get; set; }
    public int Periods { get; set; }
    public string ProrateCode { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
    public virtual ICollection<AccountingAsset> AccountingAssets { get; set; }
  }
}