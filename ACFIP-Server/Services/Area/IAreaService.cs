using ACFIP_Server.Datasets.Area;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Services.Area
{
    public interface IAreaService
    {
        Task<List<AreaDataset>> GetAll();
    }
}
