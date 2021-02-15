using ACFIP_Server.Datasets.Account;
using ACFIP_Server.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ACFIP_Server.Services.Account
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;
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
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            account.Salt = salt;
            account.HashedPassword = hashSHA512(dataset.Password, salt);
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
            return _mapper.Map<AccountDataset>(await _uow.AccountRepo.GetFirst(filter: t => t.Id == id && t.Status && !t.DeletedFlag, includeProperties: "Role"));
        }

        public Task<List<AccountDataset>> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public async Task<AccountDataset> Login(LoginDataset dataset)
        {
            Models.Account account = await _uow.AccountRepo.GetFirst(filter: t => t.Id == dataset.Id && t.Status && !t.DeletedFlag, includeProperties: "Role");
            if (hashSHA512(dataset.Password, account.Salt) == account.HashedPassword)
            {
                return _mapper.Map<AccountDataset>(account);
            }
            return null;
        }

        // hash function, using SHA512
        private string hashSHA512(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10,
                numBytesRequested: 512 / 8));
        }
    }
}
