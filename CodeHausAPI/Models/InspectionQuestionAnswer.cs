using System;
using System.Collections.Generic;

namespace CodeHausAPI.Models
{
    public partial class InspectionQuestionAnswer
    {
        public int Id { get; set; }
        public int InpsectionQuestionId { get; set; }
        public string? InpectionQuestionTextAnswer { get; set; }
        public string? InpectionQuestionImageAnswer { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
