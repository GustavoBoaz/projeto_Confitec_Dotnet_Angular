using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.src.Queries.Requests;
using User.API.src.Queries.Responses;
using User.Core.src.Entities;
using User.Core.src.Repositories;

namespace User.API.src.Queries.Handlers
{
    public class UserQueriesHandlers : IUserQueries
    {
        private readonly ICrud<UserEntity> _repository;

        public UserQueriesHandlers(ICrud<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdResponse> HandlerAsync(GetByIdRequest query)
        {
            var user = await _repository.ReadAsync(query.Id);
            if (user == null) throw new Exception("Id de usuario não existe");

            return new GetByIdResponse(user);
        }

        public async Task<GetAllResponse> HandlerAsync()
        {
            var users = await _repository.ListAsync();
            return new GetAllResponse(users);
        }
    }
}