using ACFIP_Server.Datasets.ViolationCase;
using ACFIP_Server.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
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
                CameraId = dataset.CameraId,
                ImgUrl = dataset.ImgUrl,
                VideoUrl = dataset.VideoUrl
            };
            _uow.ViolationCaseRepo.Insert(violationCase);
            bool check = await _uow.CommitAsync() > 0;
            if (check)
            {
                dataset.Id = violationCase.Id;
                return dataset;
            }
            return null;
        }

        public async Task<ViolationDataset> GetLatest(int cameraId)
        {
            Func<IQueryable<Models.ViolationCase>, IOrderedQueryable<Models.ViolationCase>> order;
            order = v => v.OrderByDescending(t => t.CreatedTime);
            return _mapper.Map<ViolationDataset>((await _uow.ViolationCaseRepo.Get(filter: v => v.CameraId == cameraId, orderBy: order)).FirstOrDefault());
        }

        public async Task<ViolationDataset> GetOne(int id)
        {
            return _mapper.Map<ViolationDataset>(await _uow.ViolationCaseRepo.GetById(id));
        }
    }
}
