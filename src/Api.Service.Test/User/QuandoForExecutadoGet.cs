using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.User
{
    public class QuandoForExecutadoGet : UsuarioTestes
    {
        private IUserService _userService;
        private Mock<IUserService> _serviceMock;

        public QuandoForExecutadoGet()
        {

        }

        [Fact(DisplayName ="é possivel executar o metodo Get")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(UserDto);
            _userService = _serviceMock.Object;

            var result = await _userService.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Nome);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
            _userService = _serviceMock.Object;

            var _record = await _userService.Get(IdUsuario);
            Assert.Null(_record);

        }
    }
}
