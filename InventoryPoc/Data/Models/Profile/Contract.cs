using System.Collections.Generic;
using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Profile
{
  public class Contract : IEntity
  {
    public int Id { get; set; }
    public string SalesForceOpportunityId { get; set; }
    public string ProjectCode { get; set; }
    public ServiceType ServiceType { get; set; }
    public string ContractName { get; set; }
    public ContractStatus ContractStatus { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new HashSet<Group>();

    public int? ProjectManagerId { get; set; }
    public virtual Employee ProjectManager { get; set; }

    public virtual ICollection<ContractDeliverable> ContractDeliverables { get; set; } =
      new HashSet<ContractDeliverable>();
  }
}