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

namespace ACFIP.Data.Automapper
{
    class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();

            CreateMap<Camera, CameraDto>();
            CreateMap<CameraDto, Camera>();

            CreateMap<Area, AreaDto>();
            CreateMap<AreaDto, Area>();

            CreateMap<ViolationCase, ViolationCaseDto>();
            CreateMap<ViolationCaseDto, ViolationCase>();

            CreateMap<ViolationType, ViolationTypeDto>();
            CreateMap<ViolationTypeDto, ViolationType>();

            CreateMap<ViolationCaseType, ViolationCaseTypeDto>();
            CreateMap<ViolationCaseTypeDto, ViolationCaseType>();

            CreateMap<CameraConfiguration, CameraConfigurationDto>();
            CreateMap<CameraConfigurationDto, CameraConfiguration>();
        }

    }
}
