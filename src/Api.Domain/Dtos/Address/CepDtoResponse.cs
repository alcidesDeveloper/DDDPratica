using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos.Address
{
    public class CepDtoResponse
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public int MunicipioId { get; set; }
    }
}
