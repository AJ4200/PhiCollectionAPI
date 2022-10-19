using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spTruckBreakdownsResult
    {
        public string Month { get; set; }
        public int Breakdowns { get; set; }

    }
}
