using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;
using SensorApi.Models;
using SensorApi.Services;



namespace SensorApi
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
            services.Configure<SensorsDbDatabaseSettings>(Configuration.GetSection(nameof(SensorsDbDatabaseSettings)));
            services.AddControllers();
            services.AddSingleton<SensorsDbDatabaseSettings>(sp => sp.GetRequiredService<IOptions<SensorsDbDatabaseSettings>>().Value);
            //services.AddDbContext<SensorContext>(opt => opt.UseInMemoryDatabase("SensorList"));

            services.AddSingleton<SensorService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

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
