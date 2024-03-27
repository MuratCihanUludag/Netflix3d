using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Netflix3d.Persistence
{
    static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager manager = new();
                manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Netflix3d.API"));
                manager.AddJsonFile("appsettings.json");
                return manager.GetConnectionString("MsSql");
            }
        }
    }
}
