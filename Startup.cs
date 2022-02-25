using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using mongodb_dotnet_example.Infrastructure;
using mongodb_dotnet_example.Services;

namespace mongodb_dotnet_example
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
            services.Configure<GeoDatabaseSettings>(Configuration.GetSection(nameof(GeoDatabaseSettings)));
            services.Configure<GeoCodeSettings>(Configuration.GetSection(nameof(GeoCodeSettings)));

            services.AddSingleton<IGeoDatabaseSettings>(sp => sp.GetRequiredService<IOptions<GeoDatabaseSettings>>().Value);
            services.AddSingleton<IGeoCodeSettings>(sp => sp.GetRequiredService<IOptions<GeoCodeSettings>>().Value);

            services.AddTransient<IGeoCodeService, GeoCodeService>();
            services.AddTransient<IGeoService, GeoService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "mongodb_dotnet_example", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "mongodb_dotnet_example v1"));
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
