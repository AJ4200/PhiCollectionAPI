using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spSearchRequestForResult
    {
        public int RequestNumber { get; set; }
        public string Bin { get; set; }
        public string Waste { get; set; }
        public string PickUpPoint { get; set; }
        public string DropOffPoint { get; set; }
        public bool Received { get; set; }
        public bool Reported { get; set; }
    }
}
