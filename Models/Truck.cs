using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class Truck
    {
        public Truck()
        {
            Collections = new HashSet<Collection>();
            TruckIssues = new HashSet<TruckIssue>();
            TruckQueues = new HashSet<TruckQueue>();
        }

        public string TruckId { get; set; }
        public string NumberPlate { get; set; }
        public string? Bin { get; set; }
        public string Driver { get; set; }
        public bool Active { get; set; }

        public virtual Bin BinNavigation { get; set; }
        public virtual Staff DriverNavigation { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<TruckIssue> TruckIssues { get; set; }
        public virtual ICollection<TruckQueue> TruckQueues { get; set; }
    }
}