using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Netflix3d.Application.Services
{
    public static class Configuration
    {
        public static IConfigurationRoot Token
        {
            get
            {
                ConfigurationBuilder manager = new();
                manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Netflix3d.API"));
                manager.AddJsonFile("appsettings.json");
                return manager.Build();
            }
        }
    }
}
