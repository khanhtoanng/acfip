using ACFIP_Server.Datasets.Account;
using ACFIP_Server.Datasets.Area;
using ACFIP_Server.Datasets.Camera;
using ACFIP_Server.Datasets.ViolationCase;
using AutoMapper;

namespace ACFIP_Server.Datasets
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Account, AccountDataset>();
            CreateMap<Models.Camera, CameraDataset>();
            CreateMap<Models.Area, AreaDataset>();
            CreateMap<Models.ViolationCase, ViolationDataset>();
        }
    }
}
