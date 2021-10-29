using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SEMA.Data;
using SEMA.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEMA.Services
{
    public class UserEventAppService : IUserEventAppService
    {
        #region Fields
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public UserEventAppService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion
        public async Task<bool> RegisterUserOnEvent(UserEventDto userEventDto)
        {
            try
            {
                var result=await( from ue in _dbContext.UserEvents
                join u in _dbContext.User
                on ue.UserId equals u.Id
                where ue.EventId == userEventDto.EventId && u.PhoneNumber.Equals(userEventDto.PhoneNumber)
                select new { User= u }).ToListAsync();

                if (result ==null || result.Count==0)
                {
                    var user= _dbContext.User.Add(new Entities.User() { Name = userEventDto.Name, PhoneNumber = userEventDto.PhoneNumber });
                    await _dbContext.SaveChangesAsync();
                    _dbContext.UserEvents.Add(new Entities.UserEvent() { EventId = userEventDto.EventId, UserId = user.Entity.Id });
                    await _dbContext.SaveChangesAsync();
                        return true;
                 }

                return false;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
