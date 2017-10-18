using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCQRS.Commands;
using SimpleCQRS.Commands.Handlers;
using SimpleCQRS.Infrastracture;
using SimpleCQRS.Queries;
using SimpleCQRS.Queries.Handlers;

namespace SimpleCQRS
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
            services.AddMvc();
            services.AddLogging();
            services.AddScoped(typeof(AppBus));
            services.AddScoped(typeof(ServiceProvider), x => services.BuildServiceProvider());
            services.AddScoped<ICommandHandler<TestCommand>, TestCommandHandler>();
            services.AddScoped<IQueryHandler<TestQuery, int>, TestQueryHandler>();
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

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}