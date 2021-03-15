using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.Account
{
    public interface IAccountService : IBaseService<ACFIP.Data.Models.Account, AccountDto>
    {
        public Task<AccountDto> UpdateStatusAccount( AccountActivationParam param);
        public Task<AccountDto> DeleteAccount(string id);
        public Task<AccountDto> CreateAccount(AccountCreateParam param);
        public Task<AccountDto> ChangePassword(AccountPasswordParam param);
    }
}
