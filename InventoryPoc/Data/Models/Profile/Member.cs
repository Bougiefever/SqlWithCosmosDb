using System;
using System.Collections.Generic;
using InventoryPoc.Data.Enums;
using InventoryPoc.Data.Models.Inventory;

namespace InventoryPoc.Data.Models.Profile
{
  public class Member : IEntity
  {
    public int Id { get; set; }

    public string MemberName { get; set; }
    public string MemberNumber { get; set; }
    public DateTime? ExpectedStartDate { get; set; }
    public DateTime? DraftDeliveryDate { get; set; }
    public DateTime? ProjectedDate { get; set; }
    public DateTime? FinalDate { get; set; }
    public DateTime? AccountingAsOfDate { get; set; }
    public DateTime? InsuranceAsOfDate { get; set; }
    public DateTime? AppraisalAsOfDate { get; set; }
    public MemberStatus MemberStatus { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; set; }

    public virtual ICollection<InsuranceAsset> InsuranceAssets { get; set; } = new HashSet<InsuranceAsset>();
  }
}