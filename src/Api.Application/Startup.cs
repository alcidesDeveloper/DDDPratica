using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.CrossCutting.DependencyInjection;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Security;
using AutoMapper;
using CrossCutting.DependencyInjection;
using CrossCutting.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace application
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_Environment.IsEnvironment("Testing"))
            {
                Environment.SetEnvironmentVariable("DefaultConnection", "Data Source=.\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;MultipleActiveResultSets=true");
                Environment.SetEnvironmentVariable("Audience", "exAudience");
                Environment.SetEnvironmentVariable("Issuer", "ExIssuer");
                Environment.SetEnvironmentVariable("Seconds", "28800");
            }
            services.AddControllers();

            ConfigureService.ConfigureDepencies(services);
            ConfigureRepository.ConfigureRepositoryDepencies(services, Configuration);

            var configure = new MapperConfiguration(mc =>
            {

                mc.AddProfile(new DtoToModelProfile());
                mc.AddProfile(new EntityToDtoProfile());
                mc.AddProfile(new ModelToEntityProfile());
            });

            IMapper mapper = configure.CreateMapper();
            services.AddSingleton(mapper);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            /*var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(Configuration.GetSection("TokenConfigurations")).Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);
            */

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = Environment.GetEnvironmentVariable("Audience"); //tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = Environment.GetEnvironmentVariable("Issuer");  //tokenConfigurations.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            //swagger
            services.AddSwaggerGen(c =>
            {

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {

                    Description = "insira o Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                 { new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference{
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                    }
                    }, new List<string>()
                }
                });
            }); 
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(ssu =>
            {
                ssu.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso DDD");
                ssu.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
