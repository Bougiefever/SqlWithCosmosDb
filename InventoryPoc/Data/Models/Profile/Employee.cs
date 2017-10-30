using System.Collections.Generic;

namespace InventoryPoc.Data.Models.Profile
{
  public class Employee : IEntity
  {
    public int Id { get; set; }
    public string EmployeeNumber { get; set; }
    public string EmployeeName { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public int DefaultRoleId { get; set; }
    public virtual Role Role { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    public virtual ICollection<GroupUser> GroupUsers { get; set; } = new HashSet<GroupUser>();
  }
}