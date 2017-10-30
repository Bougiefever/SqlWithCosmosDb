using System;

namespace InventoryPoc.Data.Models.Profile
{
  public class Opportunity : IEntity
  {
    public int Id { get; set; }
    public string SalesforceId { get; set; }
    public string AccountId { get; set; }
    public string OpportunityName { get; set; }
    public string Service { get; set; }
    public string SubIndustry { get; set; }
    public DateTime ExpectedStartDate { get; set; }
    public string OfficeCity { get; set; }
    public string OpportunityContactId { get; set; }
    public string BillingDirectorId { get; set; }
    public string PerformingMDId { get; set; }
    public string BillingMDId { get; set; }
    public string ReferralMDId { get; set; }
    public string Industry { get; set; }
    public string EngagementId { get; set; }
  }
}