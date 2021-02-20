﻿using ACFIP.Bussiness.Services.Account;
using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
using ACFIP.Data.Helpers;
using ACFIP.Data.Repository;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

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

        public async Task<AccountDto> UpdateStatusAccount(AccountStatusParam param)
        {
            Data.Models.Account account = await _reponsitory.GetById(param.Id);
            if (account != null)
            {
                account.Status = param.Status;
                _reponsitory.Update(account);
                return await _uow.SaveAsync() > 0
                    ? _mapper.Map<AccountDto>(account)
                    : throw new Exception("Cannot update Status this account");
            }
            throw new Exception("Cannot find this account");
        }
        public async Task<AccountDto> CreateAccount(AccountCreateParam param)
        {
            Data.Models.Account account = new Data.Models.Account();
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            account.Id = param.Id;
            account.Salt = salt;
            account.HashedPassword = AppUtils.hashSHA512(param.Password, salt);
            account.RoleId = AppConstants.Role.Monitor.ID;
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
                byte[] salt = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                account.Salt = salt;
                account.HashedPassword = AppUtils.hashSHA512(param.NewPassword, salt);
                account.RoleId = AppConstants.Role.Monitor.ID;
                _uow.AccountRepository.Update(account);
                return await _uow.SaveAsync() > 0
                        ? _mapper.Map<AccountDto>(account)
                        : throw new Exception("Can not update password");
            }
            return null;
        }
    }
}