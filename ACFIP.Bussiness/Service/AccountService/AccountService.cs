using ACFIP.Bussiness.Service.Account;
using ACFIP.Data.Dtos.Accounts;
using ACFIP.Data.Repository;
using ACFIP.Data.UnitOfWork;
using AutoMapper;

namespace ACFIP.Bussiness.Service.AccountService
{
    public class AccountService : BaseService<ACFIP.Data.Models.Account, AccountDto>, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override IGenericRepository<Data.Models.Account> _reponsitory => _uow.AccountRepository;
    }
}
