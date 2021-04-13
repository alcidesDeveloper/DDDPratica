using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Email obrigatorio para login")]
        [EmailAddress(ErrorMessage ="Formato inválido")]
        [StringLength(100, ErrorMessage ="minimo de {1} caracteres")]
        public string Email { get; set; }
    }
}
