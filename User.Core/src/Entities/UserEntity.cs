using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using User.Core.src.Entities.Base;
using User.Core.src.Enums;

namespace User.Core.src.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Scholarity Escolaridade { get; set; }
    }
}