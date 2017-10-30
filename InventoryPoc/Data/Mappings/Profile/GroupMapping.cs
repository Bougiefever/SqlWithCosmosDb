using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class GroupMapping : EntityTypeConfiguration<Group>
  {
    public GroupMapping()
    {
      ToTable("Group");
      HasKey(x => x.Id);
      Property(x => x.GroupName).HasMaxLength(200).IsRequired();
      Property(x => x.GroupName2).HasMaxLength(200);
      Property(x => x.Location).HasMaxLength(200);
      Property(x => x.GroupNumber).HasMaxLength(100);
      Property(x => x.CostReplacementNewTrendDate).IsOptional();
      Property(x => x.AtReportedCost).HasPrecision(18, 2);
      HasOptional(x => x.Member).WithRequired(x => x.Group);
      HasMany(x => x.InventoryEntities).WithRequired(x => x.Group).HasForeignKey(x => x.GroupId);
      HasMany(x => x.AccountingHeaders).WithRequired(x => x.Group).HasForeignKey(x => x.GroupId);
      HasMany(x => x.ScheduledItems).WithRequired(x => x.Group).HasForeignKey(x => x.GroupId);
      HasMany(x => x.ProcessingInstructions).WithRequired(x => x.Group).HasForeignKey(x => x.GroupId);
      HasMany(x => x.Comments).WithRequired(x => x.Group).HasForeignKey(x => x.GroupId);
      HasMany(x => x.GroupUsers).WithOptional(x => x.Group).HasForeignKey(x => x.GroupId);
    }
  }
}