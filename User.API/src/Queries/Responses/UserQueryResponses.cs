using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Core.src.Entities;

namespace User.API.src.Queries.Responses
{
    public class GetByIdResponse
    {
        public GetByIdResponse(UserEntity user)
        {
            User = user;
        }

        public UserEntity User { get; set; }
    }

    public class GetAllResponse
    {
        public GetAllResponse()
        {
        }

        public GetAllResponse(List<UserEntity> users)
        {
            Users = users;
        }
        
        List<UserEntity> Users { get; set; }

        public List<UserEntity> GetUsers()
        {
            return Users;
        }
    }
}