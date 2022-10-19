#nullable disable
using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class TruckIssue
    {
        public Guid Id { get; set; }
        public string Truck { get; set; }
        public string Driver { get; set; }
        public int Request { get; set; }
        public DateTime ReportedAt { get; set; }
        public DateTime? FixedAt { get; set; }
        public string Location { get; set; }

        public virtual Staff DriverNavigation { get; set; }
        public virtual Request RequestNavigation { get; set; }
        public virtual Truck TruckNavigation { get; set; }
    }
}