using ACFIP_Server.Context;
using ACFIP_Server.Models;
using System;
using System.Threading.Tasks;

namespace ACFIP_Server.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MainContext _context;
        private bool disposed = false;
        private IGenericRepository<Account> _accountRepo;
        private IGenericRepository<Role> _roleRepo;
        private IGenericRepository<Area> _areaRepo;
        private IGenericRepository<Camera> _cameraRepo;
        private IGenericRepository<CameraConfiguration> _configRepo;
        private IGenericRepository<ViolationCase> _violationCaseRepo;
        private IGenericRepository<ViolationType> _violationTypeRepo;
        private IGenericRepository<ViolationCaseType> _violationCaseTypeRepo;
        public UnitOfWork(MainContext context)
        {
            _context = context;
        }
        public IGenericRepository<Account> AccountRepo
        {
            get { return _accountRepo ??= new GenericRepository<Account>(_context); }
        }

        public IGenericRepository<Role> RoleRepo
        {
            get { return _roleRepo ??= new GenericRepository<Role>(_context); }
        }

        public IGenericRepository<Area> AreaRepo
        {
            get { return _areaRepo ??= new GenericRepository<Area>(_context); }
        }

        public IGenericRepository<Camera> CameraRepo
        {
            get { return _cameraRepo ??= new GenericRepository<Camera>(_context); }
        }

        public IGenericRepository<CameraConfiguration> ConfigRepo
        {
            get { return _configRepo ??= new GenericRepository<CameraConfiguration>(_context); }
        }

        public IGenericRepository<ViolationCase> ViolationCaseRepo
        {
            get { return _violationCaseRepo ??= new GenericRepository<ViolationCase>(_context); }
        }

        public IGenericRepository<ViolationType> ViolationTypeRepo
        {
            get { return _violationTypeRepo ??= new GenericRepository<ViolationType>(_context); }
        }

        public IGenericRepository<ViolationCaseType> ViolationCaseTypeRepo
        {
            get { return _violationCaseTypeRepo ??= new GenericRepository<ViolationCaseType>(_context); }
        }

        public async Task<int> CommitAsync()
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
