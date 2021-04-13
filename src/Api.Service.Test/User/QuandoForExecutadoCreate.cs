using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.User
{
    public class QuandoForExecutadoCreate : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(UserDtoCreate)).ReturnsAsync(UserDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(UserDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Nome);
            Assert.Equal(EmailUsuario, result.Email);
        }
    }
}
