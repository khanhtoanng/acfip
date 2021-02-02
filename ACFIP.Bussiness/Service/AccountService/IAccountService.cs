using ACFIP.Data.Dtos.Accounts;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service.Account
{
    public interface IAccountService : IBaseService<ACFIP.Data.Models.Account, AccountDto>
    {
    }
}
