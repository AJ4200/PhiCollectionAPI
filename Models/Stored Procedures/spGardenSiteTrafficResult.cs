using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spGardenSiteTrafficResult
    {
        public string Area { get; set; }
        public int Requests { get; set; }
    }
}
