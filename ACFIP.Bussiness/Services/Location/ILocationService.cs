using ACFIP.Data.Dtos.Location;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.Location
{
    public interface ILocationService
    {
        public Task<IEnumerable<LocationDto>> GetAllLocation(int areaId);
        public Task<LocationDto> CreateLocation(LocationCreateParam param);
        public Task<LocationDto> UpdateLocation(LocationUpdateParam param);
        public Task<LocationDto> DeleteLocation(int id);

    }
}
