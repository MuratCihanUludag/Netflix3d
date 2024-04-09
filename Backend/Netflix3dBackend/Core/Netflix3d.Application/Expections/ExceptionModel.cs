using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Netflix3d.Application.Expections
{
    public class ExceptionModel : ErrorStatusCode
    {
        public string? Message { get; set; }
        public string? InnerExpection { get; set; }
        public IEnumerable<string> Errors { get; set; } 
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class ErrorStatusCode
    {
        public int? StatusCode { get; set; }
    }

}
