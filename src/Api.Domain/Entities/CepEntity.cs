using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.Entities
{
    [Table("Cep")]
    public class CepEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Cep { get; set; }
        
        [Required]
        public string Logradouro { get; set; }
        
        [StringLength(10)]
        public string Numero { get; set; }

        public int MunicipioId { get; set; }
        public MunicipioEntity Municipio { get; set; }

    }
}
