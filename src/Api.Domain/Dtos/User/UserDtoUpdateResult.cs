using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Dtos
{
    public class UserDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
