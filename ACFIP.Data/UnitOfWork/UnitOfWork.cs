using ACFIP.Data.Models;
using ACFIP.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            InitRepository();
        }

        private bool _disposed = false;

        public IGenericRepository<Account> AccountRepository { get; set; }

        public IGenericRepository<Camera> CameraRepository { get; set; }


        public IGenericRepository<Role> RoleRepository { get; set; }

        public IGenericRepository<ViolationCase> ViolationCaseRepository { get; set; }

        public IGenericRepository<ViolationType> ViolationTypeRepository { get; set; }

        public IGenericRepository<CameraSetting> CameraSettingRepository{ get; set; }

        public IGenericRepository<CameraConfiguration> CameraConfigurationRepository{ get; set; }

        public IGenericRepository<Area> AreaRepository{ get; set; }

        public IGenericRepository<ViolationCaseType> ViolationCaseTypeRepository{ get; set; }

        private void InitRepository()
        {
            AccountRepository = new GenericRepository<Account>(_context);
            CameraRepository = new GenericRepository<Camera>(_context);
            CameraSettingRepository = new GenericRepository<CameraSetting>(_context);
            CameraConfigurationRepository = new GenericRepository<CameraConfiguration>(_context);
            AreaRepository = new GenericRepository<Area>(_context);
            RoleRepository = new GenericRepository<Role>(_context);
            ViolationCaseRepository = new GenericRepository<ViolationCase>(_context);
            ViolationTypeRepository = new GenericRepository<ViolationType>(_context);
            ViolationCaseTypeRepository = new GenericRepository<ViolationCaseType>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
