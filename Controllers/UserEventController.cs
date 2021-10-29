using Microsoft.AspNetCore.Mvc;
using SEMA.Dto;
using SEMA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEMA.Controllers
{
    public class UserEventController : Controller
    {
        private readonly IEventAppService _eventAppService;
        private readonly IUserEventAppService _userEventAppService;

        public UserEventController(IEventAppService eventAppService, IUserEventAppService userEventAppService)
        {
            _eventAppService = eventAppService;
            _userEventAppService = userEventAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
       public async Task<IActionResult> AddUser( UserEventDto userEventDto)
        {
            var eventResult=await _eventAppService.GetByIdAsync(userEventDto.EventId);
            if (eventResult==null || !eventResult.Status)
            {
                return  new JsonResult(new { Message= "Can not to add user in this event ", Success = false });
            }
           var result= await _userEventAppService.RegisterUserOnEvent(userEventDto);
            if (result)
            {
                return  new JsonResult(new { Message = "Register is Successfully" ,Success= true });

            }
            return new JsonResult(new { Message = "User is Alerdy Registerd " ,Success = false});

        }

        
    }
}
