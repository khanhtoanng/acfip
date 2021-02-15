using ACFIP_Server.Datasets.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACFIP_Server.Services.Account
{
    public interface IAccountService
    {
        Task<AccountDataset> Create(RegisterDataset dataset);
        Task<AccountDataset> Login(LoginDataset dataset);
        Task<List<AccountDataset>> GetAccounts();
        Task<AccountDataset> GetAccount(int id);
        Task<bool> ChangeStatus(int id, bool status);
        Task<bool> ChangePassword(int id, string oldPass, string newPass);
    }
}
