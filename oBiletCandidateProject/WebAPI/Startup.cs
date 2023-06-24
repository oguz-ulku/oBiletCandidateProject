using DataModels.Interfaces;
using DataModels.Others;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using WebAPI.Services;

namespace WebAPI
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

            services.AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddJsonOptions(opt =>
                {
                    var serializerOptions = opt.JsonSerializerOptions;
                    serializerOptions.IgnoreNullValues = true;
                    serializerOptions.IgnoreReadOnlyProperties = false;
                    serializerOptions.WriteIndented = true;
                });


            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "oBiletCandidateApiProject",
                    Description = "Swagger surface",
                    Contact = new OpenApiContact
                    {
                        Name = "Oğuz Ülkü",
                        Email = "oguz-ulku@hotmail.com",
                        Url = new Uri("http://www.oguzulku.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("http://www.oguzulku.com")
                    }
                });
            });

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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "oBilet Candidate Api Project v1.0");
            });
        }

        private void RegisterServices(IServiceCollection services)
        {

            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddTransient<HttpClient>();
            services.AddSingleton<IRedisCacheService, RedisCacheService>();
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IJourneyService, JourneyService>();
            services.AddTransient<IUtilityService, UtilityService>();
        }
    }
}
