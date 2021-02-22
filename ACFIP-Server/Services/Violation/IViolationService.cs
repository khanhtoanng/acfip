using ACFIP_Server.Datasets.ViolationCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Services.Violation
{
    public interface IViolationService
    {
        Task<ViolationDataset> GetOne(int id);
        Task<ViolationDataset> Create(ViolationDataset dataset);
    }
}
