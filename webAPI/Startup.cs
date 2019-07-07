using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using webAPI.Manager;
using webAPI.Repositories;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using System.IO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace webAPI
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
            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                .AddAzureAD(options => Configuration.Bind("AzureAd", options));

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    var resolver = options.SerializerSettings.ContractResolver;
                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.MaxDepth = 500;  
                });

            services.AddAutoMapper();   
            Mapper.Initialize(cfg => {
                cfg.AddCollectionMappers();
                // Configuration code
            });
            services.AddDbContext<DbAppContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddScoped<AgenciesManager>();
            services.AddScoped<AgenciesRepository>();

            services.AddScoped<RoomsManager>();
            services.AddScoped<RoomsRepository>();

            services.AddScoped<ReservationsManager>();
            services.AddScoped<ReservationsRepository>();

            services.AddScoped<UsersManager>();
            services.AddScoped<UserRepository>();

            services.AddScoped<EquipmentRoomsManager>();
            services.AddScoped<EquipmentRoomsRepository>();
            
            services.AddScoped<EquipmentsManager>();
            services.AddScoped<EquipmentsRepository>();

            services.AddScoped<IAgenciesRepository, AgenciesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            // Here add restrictions in production
            app.UseCors("CorsPolicy");  
            app.UseMvc();
        }
    }
}
