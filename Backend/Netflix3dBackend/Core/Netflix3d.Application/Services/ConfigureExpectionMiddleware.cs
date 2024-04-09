using Microsoft.AspNetCore.Builder;
using Netflix3d.Application.Expections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix3d.Application.Services
{
    public static class ConfigureExpectionMiddleware
    {
        public static void ConfigureExpectionHandleingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExpectionMiddelware>();
        }
    }
}
