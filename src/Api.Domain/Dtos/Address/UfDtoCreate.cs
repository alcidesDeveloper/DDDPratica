using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos.Address
{
    public class UfDtoCreate
    {
        [Required(ErrorMessage ="Sigla obrigatório")]
        [StringLength(2)]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(45)]
        public string Nome { get; set; }
    }
}
