using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using User.API.src.Commands.Requests;
using User.API.src.Commands.Requests.Validations;
using User.API.src.Commands.Responses;
using User.API.src.Queries.Handlers;
using User.API.src.Queries.Requests;
using User.Core.src.Entities;
using User.Core.src.Repositories;

namespace User.API.src.Commands.Handlers
{
    public class UserCommandsHandlers : IUserCommands
    {
        private readonly ICrud<UserEntity> _repository;
        private CreateUserValidation _validatorCreation = new CreateUserValidation();
        private UpdateUserValidation _validatorUpdate = new UpdateUserValidation();

        public UserCommandsHandlers(ICrud<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<SussessResponse> HandlerAsync(CreateUserRequest command)
        {

            var aux = _validatorCreation.Validate(command);

            if (!aux.IsValid) throw new Exception(MapAndSerializeJsonString(new Dictionary<string, string>()));

            await _repository.CreateAsync(new UserEntity
            {
                Nome = command.Nome,
                Sobrenome = command.Sobrenome,
                Email = command.Email,
                Escolaridade = command.Escolaridade,
                DataNascimento = command.DataNascimento
            });

            return new SussessResponse(DateTime.Now);

            // Aux functions
            string MapAndSerializeJsonString(Dictionary<string, string> errors)
            {
                foreach (var failure in aux.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
                return JsonConvert.SerializeObject(errors);
            }
        }

        public async Task<SussessResponse> HandlerAsync(UpdateUserRequest command)
        {
            var user = await _repository.ReadAsync(command.Id);
            if (user == null) throw new Exception("Id de usuario não existe");

            var aux = _validatorUpdate.Validate(command);
            if (!aux.IsValid) throw new Exception(MapAndSerializeJsonString(new Dictionary<string, string>()));

            await _repository.UpdateAsync(new UserEntity
            {
                Nome = command.Nome,
                Sobrenome = command.Sobrenome,
                Email = command.Email,
                Escolaridade = command.Escolaridade,
                DataNascimento = command.DataNascimento
            });

            return new SussessResponse(DateTime.Now);

            // Aux functions
            string MapAndSerializeJsonString(Dictionary<string, string> errors)
            {
                foreach (var failure in aux.Errors)
                {
                    errors[failure.PropertyName] = failure.ErrorMessage;
                }
                return JsonConvert.SerializeObject(errors);
            }
        }

        public async Task<SussessResponse> HandlerAsync(DeleteUserRequest command)
        {
            var user = await _repository.ReadAsync(command.Id);
            if (user == null) throw new Exception("Id de usuario não existe");

            await _repository.DeleteAsync(command.Id);

            return new SussessResponse(DateTime.Now);
        }

    }
}