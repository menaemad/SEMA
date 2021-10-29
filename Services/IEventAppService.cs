using SEMA.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEMA.Services
{
  public  interface IEventAppService

    {
        Task<List<EventDto>> GetAllAsync();
        Task<EventDto> GetByIdAsync(int Id); 
        Task CreateOrUpdateAsync(EventDto eventDto);
        Task DeleteAsync(int Id);
        Task ChangeStatus(int Id);

    }
}
