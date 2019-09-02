using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Web.Http.Cors;
using Tasklist.Business;
using Tasklist.Data;
using Tasklist.Repo;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.Swagger;

namespace Tasklist.Api
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
            services.AddScoped(typeof(ITasklistService<>), typeof(TasklistService<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddCors();
            services.AddDbContext<ApiContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:TaskDb"]));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMvcCore().AddApiExplorer();


        }


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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();
            
        }
    }
}
