using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarDelete
{
    public class RetornoDeleteBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possível Realizar o Deleted.")]
        public async Task E_Possivel_Invocar_a_Controller_Delete()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                       .ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Error", "Erro");

            var result = await _controller.DeleteUser(Guid.NewGuid());
            Assert.True(result is BadRequestResult);
        }
    }
}
