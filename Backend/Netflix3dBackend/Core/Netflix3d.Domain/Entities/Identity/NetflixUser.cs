using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Domain.Entities.Identity
{
    public class NetflixUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
