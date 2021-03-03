using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Camera;
using ACFIP.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.CameraService
{
    public interface ICameraService 
    {
        public Task<IEnumerable<CameraDto>> GetAllCamera(bool isActive);
        public Task<CameraDto> GetDetailCamera(int id);
        public Task<CameraDto> DeleteCamera(int id);
        public Task<CameraDto> CreateCamera(CameraCreateParam param);
        public Task<CameraDto> UpdateCamera(CameraUpdateParam param);
        public Task<CameraDto> UpdateStatusCamera(int id ,CameraActivationParam cameraUpdate);

    }
}
