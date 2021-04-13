using Api.Data.Context;
using Api.Domain.Entities;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {

        private ServiceProvider _serviceProvider { get; set; }

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
        }

        [Fact(DisplayName ="Crud de usuário")]
        [Trait("Crud", "UerEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserRepository _repository = new UserRepository(context);

                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Nome = Faker.Name.FullName()
                };

                var _registroCriado = await _repository.InsertAsync(_entity);

                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Nome, _registroCriado.Nome);
                Assert.False(_registroCriado.Id == Guid.Empty);

                //Teste Update
                _entity.Nome = Faker.Name.First();
                var _registroAtualizado = await _repository.UpdateAync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);
                Assert.Equal(_entity.Nome, _registroAtualizado.Nome);

                //Teste Find by Id
                var _resultById = await _repository.SelectByIdAync(_registroAtualizado.Id);
                Assert.NotNull(_resultById);
                Assert.Equal(_resultById.Email, _registroAtualizado.Email);
                Assert.Equal(_resultById.Nome, _registroAtualizado.Nome);

                //Delete
                bool deletado = await _repository.Delete(_registroAtualizado.Id);
                Assert.True(deletado);

            }
        }
    }
}
