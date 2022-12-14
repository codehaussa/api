using System;
using System.Collections.Generic;

namespace CodeHausAPI.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
