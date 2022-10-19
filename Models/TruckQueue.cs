#nullable disable
using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class TruckQueue
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessingStartedAt { get; set; }
        public string Truck { get; set; }

        public virtual Truck TruckNavigation { get; set; }
    }
}