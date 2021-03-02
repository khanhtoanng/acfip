using ACFIP_Server.Datasets;
using ACFIP_Server.Repositories;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ACFIP_Server.Services.Violation
{
    public interface IViolationService
    {
        Task<ViolationDataset> GetOne(int id);
        Task<ViolationDataset> GetLatest(int cameraId);
        Task<ViolationDataset> Create(ViolationDataset dataset);
    }
    public class ViolationService : IViolationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ViolationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ViolationDataset> Create(ViolationDataset dataset)
        {
            Models.ViolationCase violationCase = new Models.ViolationCase()
            {
                GroupCamId = dataset.GroupCamId,
                ImgUrl = dataset.ImgUrl,
                VideoUrl = dataset.VideoUrl
            };
            _uow.ViolationCaseRepo.Insert(violationCase);
            bool check = await _uow.CommitAsync() > 0;
            if (check)
            {
                dataset.Id = violationCase.Id;
                foreach (string type in dataset.Types)
                {
                    int typeId = (await _uow.ViolationTypeRepo.GetFirst(filter: t => t.Name.ToLower() == type.ToLower())).Id;
                    _uow.ViolationCaseTypeRepo.Insert(new Models.ViolationCaseType() { CaseId = violationCase.Id, TypeId = typeId });
                }
                await _uow.CommitAsync();
                return dataset;
            }
            return null;
        }

        public async Task<ViolationDataset> GetLatest(int groupCamId)
        {
            Func<IQueryable<Models.ViolationCase>, IOrderedQueryable<Models.ViolationCase>> order;
            order = v => v.OrderByDescending(t => t.CreatedTime);
            return _mapper.Map<ViolationDataset>((await _uow.ViolationCaseRepo.Get(filter: v => v.GroupCamId == groupCamId, orderBy: order)).FirstOrDefault());
        }

        public async Task<ViolationDataset> GetOne(int id)
        {
            return _mapper.Map<ViolationDataset>(await _uow.ViolationCaseRepo.GetById(id));
        }
    }
}
