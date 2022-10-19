using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spTotalRequestsByResult
    {
        public string Supervisor { get; set; }
        public int? RequestsMade { get; set; }
    }
}
