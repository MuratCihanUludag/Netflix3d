using Microsoft.AspNetCore.Identity;
using Netflix3d.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Domain.Entities.Identity
{
    public class AppUser : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
