using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Collections = new HashSet<Collection>();
            Locations = new HashSet<Location>();
            RequestBuffers = new HashSet<RequestBuffer>();
            Requests = new HashSet<Request>();
            TruckIssues = new HashSet<TruckIssue>();
            Trucks = new HashSet<Truck>();
        }

        public string Dtype { get; set; }
        public string StaffId { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string? LicenceNumber { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<RequestBuffer> RequestBuffers { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<TruckIssue> TruckIssues { get; set; }
        public virtual ICollection<Truck> Trucks { get; set; }
    }
}