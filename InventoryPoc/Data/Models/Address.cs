using Newtonsoft.Json;

namespace InventoryPoc.Data.Models
{
  public class Address : IEntity
  {
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "addressline1")]
    public string AddressLine1 { get; set; }

    [JsonProperty(PropertyName = "addessline2")]
    public string AddressLine2 { get; set; }

    [JsonProperty(PropertyName = "city")]
    public string City { get; set; }

    [JsonProperty(PropertyName = "state")]
    public string State { get; set; }

    [JsonProperty(PropertyName = "zipcode")]
    public string ZipCode { get; set; }

    [JsonProperty(PropertyName = "country")]
    public string Country { get; set; }
  }
}