using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class MemberMapping : EntityTypeConfiguration<Member>
  {
    public MemberMapping()
    {
      ToTable("Member");
      HasKey(x => x.Id);
      Property(x => x.AccountingAsOfDate).IsOptional();
      Property(x => x.DraftDeliveryDate).IsOptional();
      Property(x => x.AppraisalAsOfDate).IsOptional();
      Property(x => x.ExpectedStartDate).IsOptional();
      Property(x => x.InsuranceAsOfDate).IsOptional();
      Property(x => x.InsuranceAsOfDate).IsOptional();
      Property(x => x.FinalDate).IsOptional();
      HasMany(x => x.InsuranceAssets).WithRequired(x => x.Member).HasForeignKey(x => x.MemberId);
    }
  }
}