using ACFIP.Bussiness.Services.Account;
using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
using ACFIP.Data.Helpers;
using ACFIP.Data.Repository;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Linq;

namespace ACFIP.Bussiness.Services.AccountService
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
                account.DeletedFlag = true;
                _reponsitory.Update(account);
                return await _uow.SaveAsync() > 0
                    ? _mapper.Map<AccountDto>(account)
                    : throw new Exception("Cannot delete this account by update delFlg");
            }
            throw new Exception("Cannot find this account");

        }

        public async Task<AccountDto> UpdateStatusAccount(AccountActivationParam param)
        {
            Data.Models.Account account = await _reponsitory.GetById(param.Id);
            if (account != null)
            {
                account.IsActive = param.IsActive;
                _reponsitory.Update(account);
                return await _uow.SaveAsync() > 0
                    ? _mapper.Map<AccountDto>(account)
                    : throw new Exception("Cannot update Status this account");
            }
            throw new Exception("Cannot find this account");
        }
        public async Task<AccountDto> CreateAccount(AccountCreateParam param)
        {
            var index =  (await _uow.AccountRepository.Get(filter: el => el.RoleId == param.RoleId)).Count();
            int suffixId = index + 1;
            string prefixId = (await _uow.RoleRepository.GetById(param.RoleId)).Name;
            Data.Models.Account account = new Data.Models.Account();
            account.Id = prefixId + suffixId;
            account.Salt = AppUtils.generateSalt();
            account.HashedPassword = AppUtils.hashSHA512(param.Password, account.Salt);
            account.RoleId = param.RoleId;
            _uow.AccountRepository.Add(account);
            if (await _uow.SaveAsync() > 0)
            {
                return _mapper.Map<AccountDto>(account);
            }
            return null;
        }

        public async Task<AccountDto> ChangePassword(AccountPasswordParam param)
        {
            Data.Models.Account account = await _uow.AccountRepository.GetById(param.Id);
            if (account == null) throw new Exception("this account is not exist");
            if (AppUtils.VerifyPassword(param.OldPassword, account.HashedPassword, account.Salt))
            {
                account.Salt = AppUtils.generateSalt();
                account.HashedPassword = AppUtils.hashSHA512(param.NewPassword, account.Salt);
                _uow.AccountRepository.Update(account);
                return await _uow.SaveAsync() > 0
                        ? _mapper.Map<AccountDto>(account)
                        : throw new Exception("Can not update password");
            }
            return null;
        }

        public async Task<AccountDto> UpdateEmail(AccountEmailParam param)
        {
            Data.Models.Account account = await _uow.AccountRepository.GetById(param.Id);
            if (account == null) return null;
            account.Email = param.Email;
            _uow.AccountRepository.Update(account);
            return await _uow.SaveAsync() > 0
                    ? _mapper.Map<AccountDto>(account)
                    : throw new Exception("Can not update email");
        }
    }
}
