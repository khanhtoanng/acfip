using ACFIP.Data.Dtos.Guard;
using ACFIP.Data.Models;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.GuardService
{
    public class GuardService : IGuardService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public GuardService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<int> CountAllGuards()
        {
            return (await _uow.GuardRepository.Get()).ToList().Count();
        }

        public async Task<IEnumerable<GuardDto>> CreateGuards(List<GuardCreateParam> listParam)
        {
            IEnumerable<Guard> guards = await _uow.GuardRepository.Get();
            // if have data. Delete
            if (guards.Count() > 0)
            {
                foreach (var item in guards)
                {
                    _uow.GuardRepository.Delete(item);
                }
                await _uow.SaveAsync();
            }
            foreach (var item in listParam)
            {
                Guard guard = new Guard()
                {
                    FullName = item.FullName,
                    AreaId = (await _uow.AreaRepository.GetFirst(filter: el => el.Name == item.AreaName)).Id,
                    TimeStart = item.TimeStart,
                    TimeEnd = item.TimeEnd
                };
                _uow.GuardRepository.Add(guard);
            }
            return await _uow.SaveAsync() > 0 ? _mapper.Map<IEnumerable<GuardDto>>(await _uow.GuardRepository.Get()) : null;
        }

        public async Task<IEnumerable<GuardDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<GuardDto>>(await _uow.GuardRepository.Get(includeProperties:"Area"));
        }

    }
}
