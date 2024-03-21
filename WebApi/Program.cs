
using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using BusinessLogic.CargarData;
using BusinessLogic.Data;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApi;
using WebApi.DTOs;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope()) {
            var services = scope.ServiceProvider;
            var loggerFactory= services.GetRequiredService<ILoggerFactory>();

            try {

                var userManager = services.GetRequiredService<UserManager<Usuario>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                var identityContext = services.GetRequiredService<SeguridadDbContext>();
                await identityContext.Database.MigrateAsync();
                await SeguridadDbContextData.SeedUserAsync(userManager, roleManager);


                var context = services.GetRequiredService<MarketDbContext>();
                await context.Database.MigrateAsync();
                await MarketDbContextData.CargarDataAsync(context, loggerFactory);


            


            }
            catch (Exception ex) {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Errores en el proceso de migración productos");
            }


           

        }
        host.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
}

