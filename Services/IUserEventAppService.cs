using SEMA.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEMA.Services
{
    public  interface IUserEventAppService
    {
        Task<bool> RegisterUserOnEvent(UserEventDto userEventDto);

    }
}
