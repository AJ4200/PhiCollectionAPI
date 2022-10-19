using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spDequeueTruckResult
    {
        public Guid? ID { get; set; }
        public string Truck { get; set; }
    }
}
