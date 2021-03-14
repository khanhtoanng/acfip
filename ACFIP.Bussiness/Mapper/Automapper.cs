using AutoMapper;
using ACFIP.Data.Dtos.Role;
using ACFIP.Data.Dtos.Accounts;
using ACFIP.Data.Dtos.Camera;
using ACFIP.Data.Dtos.ViolationCase;
using ACFIP.Data.Dtos.ViolationType;
using ACFIP.Data.Models;
using ACFIP.Data.Dtos.Area;
using ACFIP.Data.Dtos.ViolationCaseType;
using ACFIP.Data.Dtos.CameConfiguration;
using ACFIP.Data.Dtos.Location;
using ACFIP.Data.Dtos.Policy;
using ACFIP.Data.Dtos.Guard;

namespace ACFIP.Bussiness.Mapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();

            CreateMap<Camera, CameraDto>()
                .ForMember(des => des.Height, src => src.MapFrom(t => t.Config.Height))
                .ForMember(des => des.Angle, src => src.MapFrom(t => t.Config.Angle))
                .ForMember(des => des.LocationDescription, src => src.MapFrom(t => t.Location.Description))
                .ForMember(des => des.AreaName, src => src.MapFrom(t => t.Location.Area.Name))
                .ForMember(des => des.AreaId, src => src.MapFrom(t => t.Location.AreaId));

            CreateMap<CameraDto, Camera>();

            CreateMap<Area, AreaDto>();
            CreateMap<AreaDto, Area>();

            CreateMap<Location, LocationDto>()
                 .ForMember(des => des.NumberOfCameras, src => src.MapFrom(t => t.Cameras.Count));
            CreateMap<LocationDto, Location>();

            CreateMap<ViolationCase, ViolationCaseDto>();
            CreateMap<ViolationCaseDto, ViolationCase>();

            CreateMap<ViolationType, ViolationTypeDto>();
            CreateMap<ViolationTypeDto, ViolationType>();

            CreateMap<ViolationCaseType, ViolationCaseTypeDto>();
            CreateMap<ViolationCaseTypeDto, ViolationCaseType>();

            CreateMap<CameraConfiguration, CameraConfigurationDto>();
            CreateMap<CameraConfigurationDto, CameraConfiguration>();

            CreateMap<Policy, PolicyDto>();
            CreateMap<PolicyDto, Policy>();

            CreateMap<Guard, GuardDto>();
            CreateMap<GuardDto, Guard>();
        }

    }
}
