using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using ACFIP.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ACFIP.Data.Helpers;
using ACFIP.Data.UnitOfWork;
using Microsoft.OpenApi.Models;
using ACFIP.Data.AppContext;
using ACFIP.Bussiness.Services.Account;
using ACFIP.Bussiness.Services.AccountService;
using ACFIP.Bussiness.Services.CameraService;
using ACFIP.Bussiness.Services.ViolationCaseService;
using ACFIP.Bussiness.Services.AuthenticationService;
using ACFIP.Bussiness.Services.AreaService;
using Microsoft.AspNetCore.Mvc;
using ACFIP.Core.Settings;
using Newtonsoft.Json;
using ACFIP.Bussiness.Services.Role;
using ACFIP.Bussiness.Services.ViolationType;
using ACFIP.Bussiness.Services.GroupCamera;

namespace ACFIP.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add Configuration Singleton
            var config = new AppSettings();
            Configuration.Bind("AppSettings", config);
            services.AddSingleton(config);

            // Cors configure
            services.AddCors(opts =>
            {
                opts.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            });

            // configure controller
            services.AddControllers();
            //services.AddControllers().AddNewtonsoftJson(
            //options =>
            //{
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //}); 

            // add config connection string to database
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(config.DbConnectionString));

            // add config auto mapper
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ACFIP.Bussiness.Mapper.Automapper>();
            });

            // Add jwt authentication
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;

                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.JwtSecret)),
                        ValidateIssuer = true,
                        ValidIssuer = config.Issuer,
                        ValidateAudience = true,
                        ValidAudience = config.Audience,
                        RequireExpirationTime = false
                    };
                });

            // connect unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //DI for all service
            ServiceAddScoped(services);

            // add config swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FPTU - ACFIP API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {new OpenApiSecurityScheme{Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }}, new List<string>()}
                });
            });
            // API versioning
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
        }

        public void ServiceAddScoped(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICameraService, CameraService>();
            services.AddScoped<IViolationCaseService, ViolationCaseService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IViolationTypeService, ViolationTypeService>();
            services.AddScoped<IGroupCameraService, GroupCameraService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseExceptionHandler("/error");

            app.UseCors("AllowAll");

            // add swagger
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FPTU - ACFIP API"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
