using Convey;
using Convey.HTTP;
using Convey.Types;
using Convey.WebApi;
using Jaeger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TransportOrkiestraReservation.Data.AppDbContext;
using TransportOrkiestraReservation.Repositories;

namespace TransportOrkiestraReservation
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConvey().AddWebApi().AddCore().Build();
            services.AddSingleton<ITransportRepository, TransportRepository>();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase(databaseName: "DbContextInMemory");

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api2", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api2 v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCore();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(context.RequestServices.GetService<AppOptions>().Name);
                });
            });
        }
    }
}
