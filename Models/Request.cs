#nullable disable
using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class Request
    {
        public Request()
        {
            Collections = new HashSet<Collection>();
            TruckIssues = new HashSet<TruckIssue>();
        }

        public int RequestNumber { get; set; }
        public string Bin { get; set; }
        public int Waste { get; set; }
        public string GardenSite { get; set; }
        public string Supervisor { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Received { get; set; }

        public virtual Bin BinNavigation { get; set; }
        public virtual Location GardenSiteNavigation { get; set; }
        public virtual Staff SupervisorNavigation { get; set; }
        public virtual Waste WasteNavigation { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<TruckIssue> TruckIssues { get; set; }
    }
}