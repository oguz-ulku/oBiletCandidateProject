using DataModels.Interfaces;
using DataModels.Others;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using WebUI.Services;

namespace WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configuration.GetSection("ApplicationSettings").Bind(MySettings.Setting);
        }
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc();
          

            RegisterServices(services);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.AddTransient<HttpClient>();
            services.AddTransient<IHttpService, HttpService>();
            services.AddScoped<LocationService>();
            services.AddScoped<JourneyService>();
        }
    }
}
