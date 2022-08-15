using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.src.Commands.Responses
{
    public class SussessResponse
    {
        public SussessResponse(DateTime sussesDate)
        {
            SussesDate = sussesDate;
        }

        public DateTime SussesDate { get; set; }
    }
}