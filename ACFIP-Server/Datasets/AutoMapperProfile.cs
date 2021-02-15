using ACFIP_Server.Datasets.Account;
using AutoMapper;

namespace ACFIP_Server.Datasets
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Account, AccountDataset>();
        }
    }
}
