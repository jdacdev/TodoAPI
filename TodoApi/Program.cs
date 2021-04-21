using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoApi.Models;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            // por medio del host accedemos al context antes de poner arriba el servicio
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TodoContext>();

                    context.Database.EnsureCreated();// asegurese de que la base de datos esta creada
                    //... con esto nos aseguramos de que el OnCreatingModel se ejecuto y con ello la siembra de nuestros datos.
                }
                catch (Exception exc)
                {
                    //TODO Implement Log
                    //escribimos en el Log
                    //var logger = services.GetRequiredService<ILogger>();
                    //logger.LogError(exc, "ocurrio un error conectando con la BD.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
