using System;

namespace InventoryPoc.Data.Enums
{
  [Flags]
  public enum GroupFeatures
  {
    FloodZones = 1,
    ModeledContents = 2,
    RoundingType = 4,
    ContentRoundingType = 8
  }
}