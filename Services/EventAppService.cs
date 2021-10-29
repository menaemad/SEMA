using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEMA.Data;
using SEMA.Dto;
using SEMA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEMA.Services
{
    public class EventAppService : IEventAppService
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public EventAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<EventDto>> GetAllAsync()
        {   
            var result =await _dbContext.Events.Include(x=>x.UserEvents).ToListAsync();  
            var eventDtoList = _mapper.Map<List<EventDto>>(result);
            return eventDtoList;
        }

        public async Task CreateOrUpdateAsync(EventDto eventDto)
        {
            if (eventDto.Id == 0)
               await  CreateAsync(eventDto);
            else
                await UpdateAsync(eventDto);
        }

        public async Task DeleteAsync(int Id)
        {
            var result =await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == Id);
            _dbContext.Events.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EventDto> GetByIdAsync(int Id)
        {
           var result=await _dbContext.Events.FirstOrDefaultAsync(x=>x.Id== Id);
            return _mapper.Map<EventDto>(result);
        }

        public async Task ChangeStatus(int Id)
        {
            var result = await _dbContext.Events.FirstOrDefaultAsync(x => x.Id == Id);
            result.Status = !result.Status;
            _dbContext.Events.Update(result);
            await _dbContext.SaveChangesAsync();

        }
        #endregion

        #region Utilties
        async Task CreateAsync(EventDto eventDto)
        {
           var eventMapper=_mapper.Map<Events>(eventDto);
            await _dbContext.Events.AddAsync(eventMapper);
            await _dbContext.SaveChangesAsync();
        }

        async Task UpdateAsync(EventDto eventDto)
        {
             var result=await _dbContext.Events.FirstOrDefaultAsync(x=>x.Id== eventDto.Id);
             _mapper.Map(eventDto,result);
             _dbContext.Events.Update(result);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
