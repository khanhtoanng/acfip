using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AuthenticationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<AccountDto> Login(AccountRequestParam param)
        {
            ACFIP.Data.Models.Account account = 
                (Data.Models.Account)await _uow.AccountRepository.GetFirst(
                    filter: el => el.Id == param.Id && el.Password == param.Password,
                    includeProperties: "Role");
            if (account == null)
            {
                throw new Exception("The account is not existed!!");
            }
            return _mapper.Map<AccountDto>(account);
        }
    }
}
