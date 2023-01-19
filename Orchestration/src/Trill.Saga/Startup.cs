using Convey;
using Convey.HTTP;
using Convey.Types;
using Convey.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Trill.Saga
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConvey().AddWebApi().AddCore().Build();
            //services.AddScoped<LogContextMiddleware>();
            //services.AddSingleton<ICorrelationIdFactory, CorrelationIdFactory>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            //app.UseMiddleware<LogContextMiddleware>();

            //dodane
            app.UseHttpsRedirection();
            
            app.UseRouting();
            app.UseCore();

            //dodane
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
