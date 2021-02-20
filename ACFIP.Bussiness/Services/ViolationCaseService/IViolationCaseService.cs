﻿using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.ViolationCase;
using ACFIP.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.ViolationCaseService
{
    public interface IViolationCaseService
    {
        public Task<ViolationCaseDto> CreateViolation(ViolationCreateParam param);
        public Task<IEnumerable<ViolationCaseDto>> GetAllViolation(ViolationRequestParam param);
        public Task<ViolationCaseDto> GetDetailViolation(int id);
    }
}