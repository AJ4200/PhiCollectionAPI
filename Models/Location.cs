#nullable disable
using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class Location
    {
        public Location()
        {
            Collections = new HashSet<Collection>();
            RequestBuffers = new HashSet<RequestBuffer>();
            Requests = new HashSet<Request>();
        }

        public string Dtype { get; set; }
        public string Address { get; set; }
        public string LocationId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Supervisor { get; set; }
        public bool Active { get; set; }

        public virtual Staff SupervisorNavigation { get; set; }
        public virtual Recycler Recycler { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<RequestBuffer> RequestBuffers { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}