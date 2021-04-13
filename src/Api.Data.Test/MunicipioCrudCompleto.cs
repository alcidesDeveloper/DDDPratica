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
    public class MunicipioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider { get; set; }

        public MunicipioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
        }

        [Fact(DisplayName = "Crud Municipio")]
        public async Task E_Possivel_Realizar_CRUD_Municipio()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {

                UfRepository ufRepository = new UfRepository(context);

                UfEntity uf = new UfEntity
                {
                    Nome = Faker.Address.City(),
                    Sigla = Faker.Address.CityPrefix().Substring(0, 2)
                };

                var ufCreated = await ufRepository.InsertAsync(uf);

                MunicipioRepository muniRepository = new MunicipioRepository(context);

                MunicipioEntity entity = new MunicipioEntity
                {
                    Nome = Faker.Address.StreetSuffix(),
                    CdIBGE = Faker.RandomNumber.Next(1, 100),
                    UfId = ufCreated.Id
                };

                var Municipiocreated = await muniRepository.InsertAsync(entity);

                Assert.NotNull(Municipiocreated);
                Assert.Equal(entity.Nome, Municipiocreated.Nome);
                Assert.Equal(entity.CdIBGE, Municipiocreated.CdIBGE);
                Assert.Equal(entity.UfId, Municipiocreated.UfId);

            }

        }
    }
}
