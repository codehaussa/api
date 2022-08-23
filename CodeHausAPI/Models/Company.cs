using System;
using System.Collections.Generic;

namespace CodeHausAPI.Models
{
    public partial class Company
    {
        public int Id { get; set; }
        public string? CompanyCode { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FilesLocation { get; set; } = null!;
        public DateTime? DateCreated { get; set; }
    }
}
