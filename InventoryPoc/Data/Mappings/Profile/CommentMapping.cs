using System.Data.Entity.ModelConfiguration;
using InventoryPoc.Data.Models.Profile;

namespace InventoryPoc.Data.Mappings.Profile
{
  public class CommentMapping : EntityTypeConfiguration<Comment>
  {
    public CommentMapping()
    {
      ToTable("Comment");
      HasKey(x => x.Id);
    }
  }
}