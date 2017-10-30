using System;
using System.Collections.Generic;
using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Profile
{
  public class ContractDeliverable : IEntity
  {
    public int Id { get; set; }
    public DateTime? DueDate { get; set; }
    public ContractDeliverableStatus ContractDeliverableStatus { get; set; }
    public DeliveryMethodType DeliveryMethod { get; set; }
    public bool DeliverableCommitted { get; set; }
    public bool DeliverableRevised { get; set; }
    public int PrePayDays { get; set; }
    public DateTime DeliverableReceivedDate { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
    public int DeliverableId { get; set; }
    public virtual Deliverable Deliverable { get; set; }
    public virtual ICollection<DeliverableRecipient> Recipients { get; set; }
  }
}