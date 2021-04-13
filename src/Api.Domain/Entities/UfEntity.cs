using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Api.Domain.Entities
{
    [Table("UF")]
    public class UfEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        public string Sigla { get; set; }
        
        [StringLength(45)]
        public string Nome { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public IEnumerable<MunicipioEntity> Municipios { get; set; }
    }
}
