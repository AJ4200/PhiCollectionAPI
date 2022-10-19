using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhiCollectionAPI.Models
{
    public partial class spMoblieCredentialsResult
    {
        public string StaffID { get; set; }
        public string dtype { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string? LocationID { get; set; }
        public string? Address { get; set; }
    }
}
