using Api.Data.Context;
using Api.Domain.Entities;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class UFCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider { get; set; }

        public UFCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
        }

        [Fact(DisplayName = "Crud Uf")]
        public async Task E_Possivel_Realizar_CRUD_UF()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UfRepository ufRepository = new UfRepository(context);

                UfEntity entity = new UfEntity
                {
                    Nome = Faker.Address.City(),
                    Sigla = Faker.Address.CityPrefix().Substring(0,2)
                };

                var ufCreated = await ufRepository.InsertAsync(entity);

                Assert.NotNull(ufCreated);
                Assert.Equal(entity.Nome, ufCreated.Nome);
                Assert.Equal(entity.Sigla, ufCreated.Sigla);


                for(int i = 0; i< 2; i++)
                {
                    UfEntity entityList = new UfEntity
                    {
                        Nome = Faker.Address.City(),
                        Sigla = Faker.Address.CityPrefix().Substring(0, 2)
                    };

                    await ufRepository.InsertAsync(entityList);
                }

                var listUf = await ufRepository.SelectAllAync();

                Assert.NotEmpty(listUf);
                Assert.True(listUf.Count() == 3);
            
            
            }

        }
    }
}
