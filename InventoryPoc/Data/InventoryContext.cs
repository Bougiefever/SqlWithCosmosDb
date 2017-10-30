using System.Data.Entity;
using InventoryPoc.Data.Mappings;
using InventoryPoc.Data.Mappings.Inventory;
using InventoryPoc.Data.Mappings.Profile;
using InventoryPoc.Data.Models;
using InventoryPoc.Data.Models.Inventory;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data
{
  public class InventoryContext : DbContext
  {
    public InventoryContext() : base("InventoryContext")
    {
      Database.CommandTimeout = 180;
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupUser> GroupUsers { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Opportunity> Opportunities { get; set; }
    public DbSet<ScheduledItem> ScheduledItems { get; set; }
    public DbSet<ProcessingInstruction> ProcessingInstructions { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Deliverable> Deliverables { get; set; }
    public DbSet<ContractDeliverable> ContractDeliverables { get; set; }
    public DbSet<ClientContact> ClientContacts { get; set; }
    public DbSet<DeliverableRecipient> DeliverableRecipients { get; set; }


    public DbSet<InventoryEntity> InventoryEntities { get; set; }
    public DbSet<InventoryAsset> InventoryAssets { get; set; }
    public DbSet<InsuranceAsset> InsuranceAssets { get; set; }
    public DbSet<AccountingHeader> AccountingHeaders { get; set; }
    public DbSet<AccountingAsset> AccountingAssets { get; set; }

    // Reference data
    public DbSet<Status> Status { get; set; }
    public DbSet<Service> Service { get; set; }
    public DbSet<SubService> SubService { get; set; }
    public DbSet<Industry> Industry { get; set; }
    public DbSet<SubIndustry> SubIndustry { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      modelBuilder.Configurations.Add(new AddressMapping());
      modelBuilder.Configurations.Add(new ClientMapping());
      modelBuilder.Configurations.Add(new ContractMapping());
      modelBuilder.Configurations.Add(new GroupMapping());
      modelBuilder.Configurations.Add(new MemberMapping());
      modelBuilder.Configurations.Add(new CommentMapping());
      modelBuilder.Configurations.Add(new EmployeeMapping());
      modelBuilder.Configurations.Add(new RoleMapping());
      modelBuilder.Configurations.Add(new ScheduledItemMapping());
      modelBuilder.Configurations.Add(new ProcessingInstructionMapping());
      modelBuilder.Configurations.Add(new GroupUserMapping());
      modelBuilder.Configurations.Add(new DeliverableMapping());
      modelBuilder.Configurations.Add(new ContractDeliverableMapping());
      modelBuilder.Configurations.Add(new ClientContactMapping());
      modelBuilder.Configurations.Add(new OpportunityMapping());
      modelBuilder.Configurations.Add(new DeliverableRecipientMapping());

      modelBuilder.Configurations.Add(new InventoryEntityMapping());
      modelBuilder.Configurations.Add(new InventoryAssetMapping());
      modelBuilder.Configurations.Add(new InsuranceAssetMapping());
      modelBuilder.Configurations.Add(new AccountingHeaderMapping());
      modelBuilder.Configurations.Add(new AccountingAssetMapping());

      modelBuilder.Configurations.Add(new StatusMapping());
      modelBuilder.Configurations.Add(new ServiceMapping());
      modelBuilder.Configurations.Add(new SubServiceMapping());
      modelBuilder.Configurations.Add(new IndustryMapping());
      modelBuilder.Configurations.Add(new SubIndustryMapping());

    }
  }
}