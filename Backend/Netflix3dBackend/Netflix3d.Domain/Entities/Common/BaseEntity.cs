using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }

    }
}
