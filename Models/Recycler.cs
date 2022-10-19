#nullable disable
using System;
using System.Collections.Generic;

namespace PhiCollectionAPI.Models
{
    public partial class Recycler
    {
        public string RecyclerId { get; set; }
        public string Name { get; set; }
        public bool IndustrialWaste { get; set; }
        public bool CardboardandPaper { get; set; }
        public bool Plastic { get; set; }
        public bool Glass { get; set; }
        public bool GardenWaste { get; set; }
        public bool GeneralWaste { get; set; }
        public bool Active { get; set; }

        public virtual Location RecyclerNavigation { get; set; }

    }
}
