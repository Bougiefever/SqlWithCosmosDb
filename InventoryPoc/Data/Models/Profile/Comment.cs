using System;

namespace InventoryPoc.Data.Models.Profile
{
  public class Comment : IEntity
  {
    public int Id { get; set; }
    public string SystemSource { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CommentText { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
  }
}