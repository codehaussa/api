using System;
using System.Collections.Generic;

namespace CodeHausAPI.Models
{
    public partial class InspectionQuestionType
    {
        public int Id { get; set; }
        public string QuestionType { get; set; } = null!;
        public string? QuestionDisplayValue { get; set; }
        public string? QuestionOptions { get; set; }
        public ulong IsActive { get; set; }
    }
}
