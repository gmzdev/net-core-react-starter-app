using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace NetCoreReactStarterApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isDevelopment = true;

            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var env = services.GetService<IHostingEnvironment>();

                    if (!env.IsDevelopment())
                    {
                        isDevelopment = false;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            if (isDevelopment)
            {
                BuildWebHost(args).Run();
            }
            else
            {
                BuildWebHostAsService(args).RunAsService();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //for development
        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
        }

        //for production
        public static IWebHost BuildWebHostAsService(string[] args)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);

            return WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(pathToContentRoot)
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
        }
    }
}
