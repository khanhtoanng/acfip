using ACFIP.Data.Dtos.GroupCamera;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.GroupCamera
{
    public interface IGroupCameraService
    {
        public Task<IEnumerable<GroupCameraDto>> GetAllGroupCamera(int areaId);
        public Task<GroupCameraDto> CreateGroupCamera(GroupCameraCreateParam param);
    }
}
