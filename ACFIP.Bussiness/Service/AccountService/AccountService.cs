using ACFIP.Bussiness.Service.Account;
using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
using ACFIP.Data.Repository;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service.AccountService
{
    public class AccountService : BaseService<ACFIP.Data.Models.Account, AccountDto>, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<Data.Models.Account> _reponsitory => _uow.AccountRepository;

        public async Task<AccountDto> DeleteAccount(string id)
        {
            ACFIP.Data.Models.Account account = await _reponsitory.GetById(id);
            if (account != null)
            {
                account.DelFlg = 1;
                _reponsitory.Update(account);
                return await _uow.SaveAsync() > 0
                    ? _mapper.Map<AccountDto>(account)
                    : null;
            }
            throw new Exception("Cannot find this account");

        }

        public async Task<bool> UpdateStatusAccount(AccountStatusParam param)
        {
            ACFIP.Data.Models.Account account = await _reponsitory.GetById(param.Id);
            if (account != null)
            {
                account.Status = param.Status;
                _reponsitory.Update(account);
                return await _uow.SaveAsync() > 0;
            }
            throw new Exception("Cannot find this account");
        }
    }
}
