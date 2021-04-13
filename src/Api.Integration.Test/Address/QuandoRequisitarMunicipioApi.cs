using Api.Domain.Dtos.Address;
using Api.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Address
{
    public class QuandoRequisitarMunicipioApi : BaseIntegration
    {
        [Fact]
        public async Task E_possivel_Crud_Municipio()
        {

            MunicipioDtoCreate dtoCreate = new MunicipioDtoCreate
            {
                Nome = Faker.Address.CityPrefix(),
                CdIBGE = Faker.RandomNumber.Next(1, 5000),
                UfId = 1
            };

            //Post
            var result = await PostJsonAsync(dtoCreate, $"{hostApi}municipio", client);
            Assert.True(result.StatusCode == HttpStatusCode.Created);

            //GetAll
            var resultGetAll = await client.GetAsync($"{hostApi}municipio");
            var resultJson = await resultGetAll.Content.ReadAsStringAsync();
            var dtos = JsonConvert.DeserializeObject<List<MunicipioEntity>>(resultJson);

            Assert.True(resultGetAll.StatusCode == HttpStatusCode.OK);
            Assert.NotEmpty(dtos);
            Assert.True(dtos.Count() > 0);
        }
    }
}
