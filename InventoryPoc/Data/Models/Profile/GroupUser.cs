namespace InventoryPoc.Data.Models.Profile
{
  public class GroupUser : IEntity
  {
    public int Id { get; set; }
    public int? EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    public int? GroupId { get; set; }

    public virtual Group Group { get; set; }
    public int? RoleId { get; set; }
    public virtual Role Role { get; set; }
  }
}