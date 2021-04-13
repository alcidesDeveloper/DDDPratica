using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Service.Test.User
{
    public class UsuarioTestes
    {
        public static string NomeUsuario { get; set; }
        public static string EmailUsuario { get; set; }
        public static string NomeUsuarioAlterado { get; set; }
        public static string EmailUsuarioAlterado { get; set; }

        public static Guid IdUsuario { get; set; }

        public List<UserDto> listUserDto = new List<UserDto>();
        
        public UserDto UserDto;

        public UserDtoCreate UserDtoCreate;

        public UserDtoCreateResult UserDtoCreateResult;

        public UserDtoUpdate UserDtoUpdate;
        
        public UserDtoUpdateResult UserDtoUpdateResult;

        public UsuarioTestes()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            for (int i=0; i<10; i++)
            {
                var dto = new UserDto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                listUserDto.Add(dto);
            }

            UserDto = new UserDto
            {
                Id = IdUsuario,
                Nome = NomeUsuario,
                Email = EmailUsuario
            };

            UserDtoCreate = new UserDtoCreate
            {
                Nome = NomeUsuario,
                Email = EmailUsuario
            };

            UserDtoCreateResult = new UserDtoCreateResult
            {
                Nome = NomeUsuario,
                Email = EmailUsuario,
                Id = IdUsuario,
                CreateAt = DateTime.UtcNow
            };

            UserDtoUpdate = new UserDtoUpdate
            {
                Nome = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                Id = IdUsuario
            };

            UserDtoUpdateResult = new UserDtoUpdateResult
            {
                Nome = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                Id = IdUsuario,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
