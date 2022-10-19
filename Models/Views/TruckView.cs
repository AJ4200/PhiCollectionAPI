#nullable disable
using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class TruckView
    {
        public string TruckId { get; set; }
        public string NumberPlate { get; set; }
        public string Bin { get; set; }
        public string Driver { get; set; }
    }
}