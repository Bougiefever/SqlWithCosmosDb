using System.Collections.Generic;
using InventoryPoc.Data.Enums;

namespace InventoryPoc.Data.Models.Profile
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string SalesForceAccountId { get; set; }
        public string ClientName { get; set; }
        public IndustryType Industry { get; set; }
        public SubIndustryType SubIndustry { get; set; }
        public ClientStatus ClientStatus { get; set; }
        public int ServiceFrequency { get; set; }

    public Address Address { get; set; }
    public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
  }
}