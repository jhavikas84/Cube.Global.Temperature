using Cube.Global.Temperature.Core.Implementation;
using Cube.Global.Temperature.Core.Interface;
using Cube.Global.Temperature.Wep.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Cube.Global.Wep.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddTransient<ITemperatureService, TemperatureService>()
                .AddTransient<IKelvinTemperature, KelvinTemperature>()
                .AddTransient<ICelsiusTemperature, CelsiusTemperature>()
                .AddTransient<IFahrenheitTemperature, FahrenheitTemperature>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cube.Global.Wep.Api", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cube.Global.Wep.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
