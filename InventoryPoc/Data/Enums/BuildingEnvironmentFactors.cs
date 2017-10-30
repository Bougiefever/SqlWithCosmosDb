using System;

namespace InventoryPoc.Data.Enums
{
  [Flags]
  public enum BuildingEnvironmentFactors
  {
    Climate = 1,
    Seismic = 2,
    Wind = 4
  }
}