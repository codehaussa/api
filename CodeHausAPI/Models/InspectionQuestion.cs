using System;
using System.Collections.Generic;

namespace CodeHausAPI.Models
{
    public partial class InspectionQuestion
    {
        public int Id { get; set; }
        public int InspectionQuestionTypeId { get; set; }
        public string InspectionQuestion1 { get; set; } = null!;
        public ulong IsActive { get; set; }
    }
}
