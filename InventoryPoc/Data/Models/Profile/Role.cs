using System.Collections.Generic;

namespace InventoryPoc.Data.Models.Profile
{
  public class Role : IEntity
  {
    public int Id { get; set; }
    public string RoleName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    public virtual ICollection<GroupUser> GroupUsers { get; set; } = new HashSet<GroupUser>();
  }
}