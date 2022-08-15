using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.src.Queries.Requests
{
    public class GetByIdRequest
    {
        public GetByIdRequest(string id)
        {
            Id = id;
        }
        
        public string Id { get; set; }
    }

    public class GetAllRequest
    {

    }

}