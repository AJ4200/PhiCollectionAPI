#nullable disable
using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class Waste
    {
        public Waste()
        {
            RequestBuffers = new HashSet<RequestBuffer>();
            Requests = new HashSet<Request>();
        }

        public int WasteNumber { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }

        public virtual ICollection<RequestBuffer> RequestBuffers { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}