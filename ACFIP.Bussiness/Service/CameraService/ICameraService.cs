using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Camera;
using ACFIP.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service.CameraService
{
    public interface ICameraService 
    {
        public Task<IEnumerable<CameraDto>> GetAllCamera(PagingRequestParam param);
        public Task<CameraDto> GetDetailCamera(int id);
        public Task<CameraDto> DeleteCamera(int id);
        public Task<CameraDto> CreateCamera(CameraRequestParam param);
        public Task<CameraDto> UpdateCamera(CameraRequestParam param);
        public Task<bool> UpdateStatusCamera(CameraStatus cameraUpdate);

    }
}
