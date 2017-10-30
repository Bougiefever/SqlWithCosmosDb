using System.Web.Security;
using Newtonsoft.Json;

namespace InventoryPoc.Data.Models
{
  public interface IEntity
  {
    int Id { get; set; }
  }
}