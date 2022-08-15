using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using User.Core.src.Enums;

namespace User.API.src.Commands.Requests.Validations
{
    public class CreateUserValidation : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("O email é obrigatório");

            RuleFor(x => x.DataNascimento)
                .Must(InvalidDate).WithMessage("A data de nascimento é inválida");
            
            RuleFor(x => x.Escolaridade)
                .IsInEnum().WithMessage("A escolaridade é inválida");
        }

        private bool InvalidDate(DateTime dataNascimento)
        {
            return dataNascimento <= DateTime.Now;
        }
    }

    public class UpdateUserValidation : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidation()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("O email é obrigatório");

            RuleFor(x => x.DataNascimento)
                .Must(InvalidDate).WithMessage("A data de nascimento é inválida");
            
            RuleFor(x => x.Escolaridade)
                .IsInEnum().WithMessage("A escolaridade é inválida");
        }
        private bool InvalidDate(DateTime dataNascimento)
        {
            return dataNascimento <= DateTime.Now;
        }
    }
}