using ACFIP.Data.Dtos.ViolationType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.ViolationType
{
    public interface IViolationTypeService
    {
        public Task<IEnumerable<ViolationTypeDto>> GetAllTypes();
    }
}
