using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spPendingRequestsForResult
    {
        public int RequestNumber { get; set; }
        public string Bin { get; set; }
        public string Waste { get; set; }
        public DateTime RequestedAt { get; set; }
        public string Status { get; set; }
    }
}
