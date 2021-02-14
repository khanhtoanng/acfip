using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service.Account
{
    public interface IAccountService : IBaseService<ACFIP.Data.Models.Account, AccountDto>
    {
        public Task<bool> UpdateStatusAccount(AccountStatusParam param);
        public Task<AccountDto> DeleteAccount(string id);
    }
}
