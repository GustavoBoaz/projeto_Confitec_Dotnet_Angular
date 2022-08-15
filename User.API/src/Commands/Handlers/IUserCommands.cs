using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.src.Commands.Requests;
using User.API.src.Commands.Responses;

namespace User.API.src.Commands.Handlers
{
    public interface IUserCommands
    {
        Task<SussessResponse> HandlerAsync(CreateUserRequest command);
        Task<SussessResponse> HandlerAsync(UpdateUserRequest command);
        Task<SussessResponse> HandlerAsync(DeleteUserRequest command);
    }
}