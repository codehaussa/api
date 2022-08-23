using System;
using System.Collections.Generic;

namespace CodeHausAPI.Models
{
    public partial class InspectionTemplate
    {
        public int Id { get; set; }
        public string? InspectionTemplateName { get; set; }
        public string? InspectionSectionIds { get; set; }
        public ulong IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
