#nullable disable
using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class RequestLog
    {
        public int RequestNumber { get; set; }
        public string Bin { get; set; }
        public string Waste { get; set; }
        public string GardenSite { get; set; }
        public string Supervisor { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Received { get; set; }
    }
}