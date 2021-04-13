using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos.User
{
    public class UserDtoCreate
    {
        [Required(ErrorMessage = "Nome não informado")]
        [MaxLength(60, ErrorMessage = "Nome com tamanho máximo de {1} caracteres")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Formato inválido")]
        [Required(ErrorMessage = "Email obrigatorio")]
        public string Email { get; set; }
    }
}
