using System;
using System.Collections.Generic;
using InventoryPoc.Data.Enums;
using InventoryPoc.Data.Models.Inventory;

namespace InventoryPoc.Data.Models.Profile
{
  public class Group : IEntity
  {
    public int Id { get; set; }

    public string GroupName { get; set; }
    public string GroupName2 { get; set; }
    public string Location { get; set; }
    public string GroupNumber { get; set; }

    public ProcessingType ProcessingType { get; set; }
    public int YearsProjected { get; set; }
    public DateTime? CostReplacementNewTrendDate { get; set; }
    public GroupFeatures GroupFeatures { get; set; }

    public decimal AtReportedCost { get; set; }
    public int ContractId { get; set; }
    public Contract Contract { get; set; }

    public Member Member { get; set; }

    public virtual ICollection<InventoryEntity> InventoryEntities { get; set; } = new HashSet<InventoryEntity>();
    public virtual ICollection<AccountingHeader> AccountingHeaders { get; set; } = new HashSet<AccountingHeader>();
    public virtual ICollection<ScheduledItem> ScheduledItems { get; set; } = new HashSet<ScheduledItem>();

    public virtual ICollection<ProcessingInstruction> ProcessingInstructions { get; set; } =
      new HashSet<ProcessingInstruction>();

    public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    public virtual ICollection<GroupUser> GroupUsers { get; set; } = new HashSet<GroupUser>();

    public virtual ICollection<ContractDeliverable> ContractDeliverables { get; set; } =
      new HashSet<ContractDeliverable>();
  }
}