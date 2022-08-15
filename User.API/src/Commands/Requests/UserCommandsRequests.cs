using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Core.src.Enums;

namespace User.API.src.Commands.Requests
{
    public class CreateUserRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Scholarity Escolaridade { get; set; }
    }

    public class UpdateUserRequest
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Scholarity Escolaridade { get; set; }
    }

    public class DeleteUserRequest
    {
        public DeleteUserRequest(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}