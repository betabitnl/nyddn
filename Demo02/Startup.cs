using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Demo02.MiddlewareExample;
using Demo02.Configuration;
using Demo02.DependencyExample;
using Demo.EfCore.Standard.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo02
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            //TODO: 1.2 configuration builder
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //TODO: 1.3 adding mvc
            // Add framework services.
            services.AddMvc();


            //TODO: 4.1 Configuration options
            services.AddOptions();
            services.Configure<ComplexConfiguration>(Configuration.GetSection(nameof(ComplexConfiguration)));

            //TODO: 2.1 adding swaggerget in config
            services.AddSwaggerGen((c) =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My API", Version = "v1" });
            });

            //TODO: 6.1 Dependency injection types
            services.AddTransient<ISomethingClass, SomethingClass>();
            //services.AddScoped<ISomethingClass, SomethingClass>();
            //services.AddSingleton<ISomethingClass, SomethingClass>();

            //TODO: EF1.1 add db context to DI
            services.AddDbContext<AwDbContext>((options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AwDbContext"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            //TODO: 5.1 Custom middleware
            app.UseHelloFromMiddleWare();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

            //TODO: 2.2 adding swagger and ui to middleware
            app.UseSwagger();
            app.UseSwaggerUI((c) =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
