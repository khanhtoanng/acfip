using ACFIP.Data.AppContext;
using ACFIP.Data.Models;
using ACFIP.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Data.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationContext _context;
        private bool disposed = false;
        private IGenericRepository<Account> _accountRepository;
        private IGenericRepository<Role> _roleRepository;
        private IGenericRepository<Area> _areaRepository;
        private IGenericRepository<Camera> _cameraRepository;
        private IGenericRepository<CameraCamConfig> _camConfigRepository;
        private IGenericRepository<CameraConfiguration> _configRepository;
        private IGenericRepository<ViolationCase> _violationCaseRepository;
        private IGenericRepository<ViolationType> _violationTypeRepository;
        private IGenericRepository<ViolationCaseType> _violationCaseTypeRepository;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }
        public IGenericRepository<Account> AccountRepository
        {
            get { return _accountRepository ??= new GenericRepository<Account>(_context); }
        }

        public IGenericRepository<Role> RoleRepository
        {
            get { return _roleRepository ??= new GenericRepository<Role>(_context); }
        }

        public IGenericRepository<Area> AreaRepository
        {
            get { return _areaRepository ??= new GenericRepository<Area>(_context); }
        }

        public IGenericRepository<Camera> CameraRepository
        {
            get { return _cameraRepository ??= new GenericRepository<Camera>(_context); }
        }

        public IGenericRepository<CameraCamConfig> CameraCamConfigRepository
        {
            get { return _camConfigRepository ??= new GenericRepository<CameraCamConfig>(_context); }
        }

        public IGenericRepository<CameraConfiguration> CameraConfigurationRepository
        {
            get { return _configRepository ??= new GenericRepository<CameraConfiguration>(_context); }
        }

        public IGenericRepository<ViolationCase> ViolationCaseRepository
        {
            get { return _violationCaseRepository ??= new GenericRepository<ViolationCase>(_context); }
        }

        public IGenericRepository<ViolationType> ViolationTypeRepository
        {
            get { return _violationTypeRepository ??= new GenericRepository<ViolationType>(_context); }
        }

        public IGenericRepository<ViolationCaseType> ViolationCaseTypeRepository
        {
            get { return _violationCaseTypeRepository ??= new GenericRepository<ViolationCaseType>(_context); }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
