using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Domain.Entities
{
    [Table("Municipio")]
    public class MunicipioEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        
        public int CdIBGE { get; set; }

        public int UfId { get; set; }
        public UfEntity Uf { get; set; }

        public IEnumerable<CepEntity> Ceps { get; set; }
    }
}
