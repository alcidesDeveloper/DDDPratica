using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos.Address
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string Nome { get; set; }

        public int CdIBGE { get; set; }

        [Required(ErrorMessage = "UF é obrigatório")]
        public int UfId { get; set; }
    }
}
