using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spWasteDroppedOffResult
    {
        public string WasteType { get; set; }
        public int? NumberOfLoads { get; set; }
        public string Month { get; set; }
        public decimal? Tonnage { get; set; }
    }
}
