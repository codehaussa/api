using System;
using System.Collections.Generic;

namespace CodeHausAPI.Models
{
    public partial class Inspection
    {
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public int AssignedUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public int InspectionClientId { get; set; }
        public int InspectionTemplateId { get; set; }
    }
}
