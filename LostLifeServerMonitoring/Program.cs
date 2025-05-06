/**************************************************************************\
    Copyright (C) 2024-2025 SkyForge Corporation. All Rights Reserved.
    Author: Stepan Myasnikov --> tenxdeveloper.
\**************************************************************************/

using System.Text.Json;
using LostLifeServerMonitoring.Models;

namespace LostLifeServerMonitoring
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args);
            
            var host = builder.Build();
            
            host.Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            { 
                webBuilder.UseStartup<Startup>();
            });
            
            return hostBuilder;
        }
    }
    
}