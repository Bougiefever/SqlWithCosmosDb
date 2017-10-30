using System.Collections.Generic;
using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Profile
{
  public class Deliverable : IEntity
  {
    public int Id { get; set; }
    public string DeliverableName { get; set; }
    public DeliverableType DeliverableType { get; set; }
    public virtual ICollection<ContractDeliverable> ContractDeliverables { get; set; }
  }
}