#nullable disable
using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class RequestBuffer
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessingStartedAt { get; set; }
        public string Bin { get; set; }
        public int Waste { get; set; }
        public string GardenSite { get; set; }
        public string Supervisor { get; set; }

        public virtual Bin BinNavigation { get; set; }
        public virtual Location GardenSiteNavigation { get; set; }
        public virtual Staff SupervisorNavigation { get; set; }
        public virtual Waste WasteNavigation { get; set; }
    }
}
