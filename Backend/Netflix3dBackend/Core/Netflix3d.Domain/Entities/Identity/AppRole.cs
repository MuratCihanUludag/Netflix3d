using Microsoft.AspNetCore.Identity;
using Netflix3d.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Domain.Entities.Identity
{
    public class AppRole : BaseEntity
    {
        public string RoleName { get; set; }    
        public List<AppUser> Users { get; set; }
    }
}
