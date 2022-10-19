using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spCurrentMonthOverviewResult
    {
        public int LandfillLoads { get; set; }
        public decimal LandfillTonnage { get; set; }
        public int RecycledLoads { get; set; }
        public decimal RecycledTonnage { get; set; }
        public int Breakdowns { get; set; }
    }
}
