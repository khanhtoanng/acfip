using ACFIP_Server.Datasets;
using ACFIP_Server.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ACFIP_Server.Helpers;
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

    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public Task<bool> ChangePassword(int id, string oldPass, string newPass)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeStatus(int id, bool status)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountDataset> Create(RegisterDataset dataset)
        {
            Models.Account account = new Models.Account();
            account.Salt = PasswordHelper.generateSalt();
            account.HashedPassword = PasswordHelper.hashSHA512(dataset.Password, account.Salt);
            account.RoleId = dataset.RoleId;
            _uow.AccountRepo.Insert(account);
            if (await _uow.CommitAsync() > 0)
            {
                return _mapper.Map<AccountDataset>(account);
            }
            return null;
        }

        public async Task<AccountDataset> GetAccount(int id)
        {
            return _mapper.Map<AccountDataset>(await _uow.AccountRepo.GetFirst(filter: t => t.Id == id && t.IsActive && !t.DeletedFlag, includeProperties: "Role"));
        }

        public Task<List<AccountDataset>> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public async Task<AccountDataset> Login(LoginDataset dataset)
        {
            Models.Account account = await _uow.AccountRepo.GetFirst(filter: t => t.Id == dataset.Id && t.IsActive && !t.DeletedFlag, includeProperties: "Role");
            if (account != null && PasswordHelper.hashSHA512(dataset.Password, account.Salt) == account.HashedPassword)
            {
                return _mapper.Map<AccountDataset>(account);
            }
            return null;
        }

        
    }
}
