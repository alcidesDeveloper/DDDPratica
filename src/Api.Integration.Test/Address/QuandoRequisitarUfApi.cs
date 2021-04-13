using Api.Domain.Dtos.Address;
using Api.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Address
{
    public class QuandoRequisitarUfApi : BaseIntegration
    {
        [Fact]
        public async Task E_possivel_realizar_crud_Uf()
        {
            UfDtoCreate dto = new UfDtoCreate
            {
                Nome = Faker.Address.City(),
                Sigla =  Faker.Address.CitySufix().Substring(0,2)
            };

            //Post
            var response = await PostJsonAsync(dto, $"{hostApi}uf", client);
            Assert.True(response.StatusCode == HttpStatusCode.Created);

            //GetAll
            var responseGetAll = await client.GetAsync($"{hostApi}uf");
            var result = await responseGetAll.Content.ReadAsStringAsync();
            var dtoUfs = JsonConvert.DeserializeObject<List<UfEntity>>(result);
            Assert.True(responseGetAll.StatusCode == HttpStatusCode.OK);
            Assert.NotEmpty(dtoUfs);
            Assert.True(dtoUfs.Count() > 0);
            
        }
    }
}
