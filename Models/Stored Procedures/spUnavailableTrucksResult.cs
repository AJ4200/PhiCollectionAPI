using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spUnavailableTrucksResult
    {
        public string Truck { get; set; }
        public string Cause { get; set; }
        public int DaysUnavailable { get; set; }
    }
}
