using System;

namespace InventoryPoc.Data.Enums
{
  [Flags]
  public enum DeliverableRecipientStatus
  {
    New = 0,
    InProgress = 1,
    Commited = 2,
    Revised = 4
  }
}