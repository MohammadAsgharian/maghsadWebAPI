using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using maghsadAPI.Models.Identity;
using maghsadAPI.Infrastructure;
using maghsadAPI.Infrastructure.Services;
using AutoMapper;
using maghsadAPI.Helper;

namespace maghsadAPI
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
            services.AddScoped<ITokenService, TokenService>();
            // services.AddScoped((typeof(Repository.GenericRepository<Models.Place>)),(typeof(Repository.Place.PlaceRepository)));
            services.AddScoped(typeof(Repository.Place.IPlaceRepository), typeof(Repository.Place.PlaceRepository));
            services.AddScoped(typeof(IGenericRepository<>), (typeof(Repository.GenericRepository<>)));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            services.AddDbContext<maghsadAPI.Data.MaghsadContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString($"CommandConStr")));
            services.AddDbContext<maghsadAPI.Data.AppIdentityDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString($"IdentityConStr")));

            services.AddIdentityServices(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "maghsadAPI", Version = "v1" });
            });
            
            services.AddCors(opt => {
                    opt.AddPolicy("CorsPolicy",policy =>{
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
                
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "maghsadAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
           app.UseCors("CorsPolicy");  
       
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
