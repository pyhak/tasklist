using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo2.Business;
using ToDo2.Data;
using ToDo2.Repo;

namespace ToDo2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase(databaseName: "ToDoDB"));
            services.AddDbContext<ApiContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:TaskDB"], b => b.MigrationsAssembly("ToDo2")));
            services.AddTransient(typeof(IToDoService<>), typeof(ToDoService<>));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=todo}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "todo",
                    template: "{controller=ToDoController}/{action=Index}/{id?}");

            });
        }
    }
}
