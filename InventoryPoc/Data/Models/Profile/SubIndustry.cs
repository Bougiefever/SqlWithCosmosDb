using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryPoc.Data.Models.Profile
{
    public class SubIndustry : IEntity
    {
        public int Id { get; set; }
        public virtual Industry Industry { get; set; }
        public string SubIndustryDescription { get; set; }
    }
}