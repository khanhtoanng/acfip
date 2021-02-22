using ACFIP_Server.Datasets.Camera;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACFIP_Server.Services.Camera
{
    public interface ICameraService
    {
        Task<List<CameraDataset>> Get(bool isActive);
    }
}
