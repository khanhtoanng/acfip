﻿using System;
using System.Collections.Generic;
using System.Text;
using ACFIP.Data.Repository;
using ACFIP.Data.Models;
using System.Threading.Tasks;

namespace ACFIP.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Account> AccountRepository { get; }
        IGenericRepository<Camera> CameraRepository { get; }
        IGenericRepository<CameraConfiguration> CameraConfigurationRepository { get; }
        IGenericRepository<CameraCamConfig> CameraCamConfigRepository { get; }
        IGenericRepository<Area> AreaRepository { get; }
        IGenericRepository<Role> RoleRepository { get; }
        IGenericRepository<ViolationCase> ViolationCaseRepository { get; }
        IGenericRepository<ViolationType> ViolationTypeRepository { get; }
        IGenericRepository<ViolationCaseType> ViolationCaseTypeRepository { get; }
        Task<int> SaveAsync();
    }
}
