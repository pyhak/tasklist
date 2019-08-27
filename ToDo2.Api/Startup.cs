using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http.Cors;
using ToDo2.Business;
using ToDo2.Data;
using ToDo2.Repo;

namespace ToDo2.Api
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
            
            //services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase(databaseName: "ToDoDB"));
            services.AddTransient(typeof(IToDoService<>), typeof(ToDoService<>));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddCors();
            services.AddDbContext<ApiContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:TaskDB"]));
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:1337").AllowAnyMethod().AllowAnyHeader());
            
            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
