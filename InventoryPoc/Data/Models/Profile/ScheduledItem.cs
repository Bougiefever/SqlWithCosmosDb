using System;

namespace InventoryPoc.Data.Models.Profile
{
  public class ScheduledItem : IEntity
  {
    public int Id { get; set; }
    public string ItemName { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime CompleteDate { get; set; }
    public DateTime DueDate { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
  }
}