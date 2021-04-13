using Api.Data.Context;
using Api.Domain.Interfaces;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureRepositoryDepencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUfRepository), typeof(UfRepository));
            services.AddScoped(typeof(IMunicipioRepository), typeof(MunicipioRepository));
            services.AddScoped(typeof(ICepRepository), typeof(CepRepository));

            services.AddDbContext<MyContext>(options => options.UseSqlServer(
                Environment.GetEnvironmentVariable("DefaultConnection")
                ));
        }
    }
}
