using ACFIP_Server.Models;
using System.Threading.Tasks;

namespace ACFIP_Server.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Account> AccountRepo { get; }
        IGenericRepository<Role> RoleRepo { get; }
        IGenericRepository<Area> AreaRepo { get; }
        IGenericRepository<Camera> CameraRepo { get; }
        IGenericRepository<CameraConfiguration> ConfigRepo { get; }
        IGenericRepository<ViolationCase> ViolationCaseRepo { get; }
        IGenericRepository<ViolationType> ViolationTypeRepo { get; }
        IGenericRepository<ViolationCaseType> ViolationCaseTypeRepo { get; }
        Task<int> CommitAsync();
    }
}
