using AutoMapper;

namespace ACFIP_Server.Datasets
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Account, AccountDataset>();
            CreateMap<Models.Camera, CameraDataset>()
                .ForMember(des => des.Height, src => src.MapFrom(t => t.Config.Height))
                .ForMember(des => des.Angle, src => src.MapFrom(t => t.Config.Angle))
                .ForMember(des => des.AreaId, src => src.MapFrom(t => t.GroupCamera.AreaId));
            CreateMap<Models.GroupCamera, GroupCamDataset>();
            CreateMap<Models.Area, AreaDataset>();
            CreateMap<Models.ViolationCase, ViolationDataset>();
        }
    }
}
