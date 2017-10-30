namespace InventoryPoc.Data.Models.Profile
{
    public class Status : IEntity
    {
        public int Id { get; set; }
        public string StatusDescription { get; set; }
    }
}