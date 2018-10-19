using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using TUI.Data;
using TUI.Error;

namespace TUI.Application
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
            services.AddDbContext<ApplicationDbContext>(optionsAction =>
                {
                    optionsAction.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlServerOptionsAction =>
                    {
                        var assembly = GetType().Assembly.FullName;
                        sqlServerOptionsAction.MigrationsAssembly(assembly);
                    });
                }
            );

            services.AddTransient<TelemetryClient>();

            services.AddDataManager();

            services.AddErrorHandler();

            services.AddMvc().AddJsonOptions(setupAction =>
                {
                    var resolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy
                        {
                            ProcessDictionaryKeys = true,
                        },
                    };
                    setupAction.SerializerSettings.ContractResolver = resolver;
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseErrorHandler();

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
