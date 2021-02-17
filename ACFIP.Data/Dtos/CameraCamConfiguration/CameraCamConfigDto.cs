using ACFIP.Data.Dtos.CameConfiguration;
using ACFIP.Data.Dtos.Camera;

namespace ACFIP.Data.Dtos.CameraCamConfiguration
{
    public class CameraCamConfigDto
    {
        public CameraDto Camera { get; set; }
        public CameraConfigurationDto Config { get; set; }
        public string ConnectionString { get; set; }
    }
}
