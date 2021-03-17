using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
using ACFIP.Data.Helpers;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AuthenticationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<AccountDto> LoginWeb(AccountLoginParam param)
        {
            ACFIP.Data.Models.Account account = 
                (Data.Models.Account)await _uow.AccountRepository.GetFirst(
                    filter: el => el.Id == param.Id && el.DeletedFlag == false,
                    includeProperties: "Role");

            if (AppUtils.VerifyPassword(param.Password, account.HashedPassword, account.Salt))
            {
                return _mapper.Map<AccountDto>(account);
            }
            return null;
        }
        public async Task<AccountDto> LoginDestop(AccountLoginParam param)
        {
            ACFIP.Data.Models.Account account =
                (Data.Models.Account)await _uow.AccountRepository.GetFirst(
                    filter: el => el.Id == param.Id && el.DeletedFlag == false,
                    includeProperties: "Role");

            if (AppUtils.VerifyPassword(param.Password, account.HashedPassword, account.Salt))
            {
                return _mapper.Map<AccountDto>(account);
            }
            return null;
        }
    }
}
