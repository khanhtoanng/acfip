using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        public Task<AccountDto> LoginWeb(AccountLoginParam param);
        public Task<AccountDto> LoginDestop(AccountLoginParam param);
    }
}
