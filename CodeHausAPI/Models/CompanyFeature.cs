using System;
using System.Collections.Generic;

namespace CodeHausAPI.Models
{
    public partial class CompanyFeature
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int FeatureId { get; set; }
        public ulong IsActive { get; set; }
    }
}
