﻿using ACFIP.Data.Dtos.Account;
using ACFIP.Data.Dtos.Accounts;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service.AuthenticationService
{
    public interface IAuthenticationService
    {
        public Task<AccountDto> Login(AccountRequestParam param);
    }
}
