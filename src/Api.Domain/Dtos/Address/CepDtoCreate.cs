using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos.Address
{
    public class CepDtoCreate
    {
        [Required(ErrorMessage ="Cep obrigatório")]
        [StringLength(10)]
        public string Cep { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [StringLength(10)]
        public string Numero { get; set; }

        [Required]
        public int MunicipioId { get; set; }
    }
}
