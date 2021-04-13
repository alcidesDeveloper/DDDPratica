using Api.Domain.Interfaces.Services.Address;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService   
    {

        public static void ConfigureDepencies(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUfService, UfService>();
            services.AddScoped<IMunicipioService, MunicipioService>();
            services.AddScoped<ICepService, CepService>();
            services.AddTransient<ILoginService, LoginService>();
        }
    }
}