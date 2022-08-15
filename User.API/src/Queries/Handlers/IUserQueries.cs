using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.src.Queries.Requests;
using User.API.src.Queries.Responses;

namespace User.API.src.Queries.Handlers
{
    public interface IUserQueries
    {
        Task<GetByIdResponse> HandlerAsync(GetByIdRequest query);
        Task<GetAllResponse> HandlerAsync();   
    }
}