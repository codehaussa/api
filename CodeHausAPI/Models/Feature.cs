using System;
using System.Collections.Generic;

namespace CodeHausAPI.Models
{
    public partial class Feature
    {
        public int Id { get; set; }
        public string FeatureName { get; set; } = null!;
        public string PageUrl { get; set; } = null!;
        public ulong IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
