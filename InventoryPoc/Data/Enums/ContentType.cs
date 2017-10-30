using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryPoc.Data.Enums
{
  public enum ContentType
  {
    Unspecified = 0,
    [Display(Name = "Computer Equipment")] ComputerEquipment = 1,
    Furniture = 2,
    Equipment = 3,
    Automotive = 4
  }
}