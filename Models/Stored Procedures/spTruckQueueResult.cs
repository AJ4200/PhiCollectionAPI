using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spTruckQueueResult
    {
        public string Truck { get; set; }
        public string Driver { get; set; }
        public DateTime Entered { get; set; }
    }
}
