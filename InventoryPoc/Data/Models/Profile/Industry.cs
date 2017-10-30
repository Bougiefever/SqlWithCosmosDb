using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryPoc.Data.Models.Profile
{
    public class Industry : IEntity
    {
        public int Id { get; set; }
        public string IndustryDescription { get; set; }
    }
}