﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryPoc.Data.Models.Profile
{
    public class SubService : IEntity
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string SubServiceDescription { get; set; }
    }
}