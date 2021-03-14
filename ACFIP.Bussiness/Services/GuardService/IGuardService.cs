using ACFIP.Data.Dtos.Guard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.GuardService
{
    public interface IGuardService
    {
        Task<IEnumerable<GuardDto>> GetAll();
        Task<IEnumerable<GuardDto>> CreateGuards(List<GuardCreateParam> listParam);

    }
}
