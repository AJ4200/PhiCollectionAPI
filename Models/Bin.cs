#nullable disable
using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class Bin
    {
        public Bin()
        {
            RequestBuffers = new HashSet<RequestBuffer>();
            Requests = new HashSet<Request>();
            Trucks = new HashSet<Truck>();
        }

        public string BinId { get; set; }
        public byte[] Qrcode { get; set; }
        public int Waste { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<RequestBuffer> RequestBuffers { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Truck> Trucks { get; set; }
    }
}