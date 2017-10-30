using System.Collections;
using System.Collections.Generic;

namespace InventoryPoc.Data.Models.Profile
{
  public class ClientContact : IEntity
  {
    public int Id { get; set; }
    public string SalesForceContactId { get; set; }
    public string ContactName { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public virtual ICollection<DeliverableRecipient> Deliverables { get; set; }
    
  }
}