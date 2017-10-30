using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Profile
{
  public class DeliverableRecipient : IEntity
  {
    public int Id { get; set; }
    public DeliverableRecipientStatus DeliverableRecipientStatus { get; set; }
    public int RecipientId { get; set; }
    public virtual ClientContact Recipient { get; set; }
    public int DeliverableId { get; set; }
    public virtual ContractDeliverable ContractDeliverable { get; set; }

  }
}