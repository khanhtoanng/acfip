using System.Threading.Tasks;

namespace ACFIP_Server.Services.Camera
{
    public interface ICameraService
    {
        Task<Models.Camera> CreateCam(string name, int areaId, string connectionStr);
        Task<Models.CameraConfiguration> CreateCamConfig();
    }
}
