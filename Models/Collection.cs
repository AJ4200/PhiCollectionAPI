#nullable disable
using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class Collection
    {
        public int CollectionNumber { get; set; }
        public string Truck { get; set; }
        public string Driver { get; set; }
        public string Destination { get; set; }
        public int Request { get; set; }
        public DateTime? ArrivedAtGardenSite { get; set; }
        public DateTime? ArrivedAtLandfill { get; set; }
        public DateTime? ArrivedAtControlStation { get; set; }
        public bool Recycled { get; set; }

        public virtual Staff DriverNavigation { get; set; }
        public virtual Location DestinationNavigation { get; set; }
        public virtual Request RequestNavigation { get; set; }
        public virtual Truck TruckNavigation { get; set; }
    }
}