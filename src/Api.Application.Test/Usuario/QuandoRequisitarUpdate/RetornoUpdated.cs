using Api.Application.Controllers;
using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarUpdate
{
    public class RetornoUpdated
    {
        private UsersController _controller;

        [Fact(DisplayName ="É possivel realizar o Update")]
        public async Task E_Possivel_Realizar_Update()
        {
            var mock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            mock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                new UserDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    Email  = email,
                    UpdateAt = DateTime.UtcNow
                });

            _controller = new UsersController(mock.Object);

            var userDtoUpdate = new UserDtoUpdate
            {
                Nome = nome,
                Email = email
            };

            var result = await _controller.UpdateData(userDtoUpdate);

            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;

            Assert.NotNull(resultValue);
            Assert.Equal(userDtoUpdate.Nome, resultValue.Nome);
            Assert.Equal(userDtoUpdate.Email, resultValue.Email);
        }
    }
}
