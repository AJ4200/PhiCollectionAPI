using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spTotalCollectionsByResult
    {
        public string Driver { get; set; }
        public int? CollectionsCompleted { get; set; }
        public int? Breakdowns { get; set; }
    }
}
