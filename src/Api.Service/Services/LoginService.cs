using Api.Domain.Dtos;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepository;
        private SigningConfigurations _signingConfigurations;
        private IConfiguration _configuration;

        public LoginService(IUserRepository userRepository, SigningConfigurations signingConfigurations, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _signingConfigurations = signingConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto loginDto)
        {
            //regras de negócio
            if (loginDto != null && !String.IsNullOrWhiteSpace(loginDto.Email))
            {

                var user = await _userRepository.FindByLogin(loginDto.Email);

                if(user != null)
                {
                    var identity = new ClaimsIdentity
                    (
                        new GenericIdentity(user.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                        }
                    );

                    var vl = Environment.GetEnvironmentVariable("Seconds");

                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(Convert.ToInt32(Environment.GetEnvironmentVariable("Seconds")));

                    var token = CreateToken(identity, createDate, expirationDate);

                    return CreateReturnToken(createDate, expirationDate, token, loginDto);
                }

                return new { 
                    authenticated = false,
                    message = "Falha na autenticação"
                };
            }


            return new
            {
                authenticated = false,
                message = "Falha na autenticação"
            };
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                SigningCredentials = _signingConfigurations.signingCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);

            return token;

        }

        private object CreateReturnToken(DateTime createDate, DateTime expirationDate, string token, LoginDto loginDto)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = loginDto.Email,
                message = "usuário logado com sucesso"
            };

        }
    }
}
