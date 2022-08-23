using System;
using System.Collections.Generic;

namespace CodeHausAPI.Models
{
    public partial class InspectionTemplateSection
    {
        public int Id { get; set; }
        public string SectionName { get; set; } = null!;
        public string? InspectionQuestionIds { get; set; }
    }
}
