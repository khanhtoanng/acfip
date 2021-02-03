using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.Camera;
using ACFIP.Data.Helper;
using ACFIP.Data.Models;
using ACFIP.Data.Repository;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service.CameraService
{
    public class CameraService : ICameraService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CameraService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CameraDto> CreateCamera(CameraRequestParam param)
        {
            // add camera to [camera]
            Camera camera = new Camera()
            {
                Name = param.Name,
                AreaId = param.AreaId,
                Status = AppConstants.Camera.ACTIVE,
            };
            _uow.CameraRepository.Add(camera);
            // if insert success
            if (await _uow.SaveAsync() > 0)
            {
                CameraSetting cameraSetting = new CameraSetting()
                {
                    Id = param.CameraSettingId
                };
                // check if camera-settings is referenced
                if (param.CameraSettingId == 0)
                {
                    //insert setting to [camera_setting]
                    cameraSetting.Height = param.Height;
                    cameraSetting.Angle = param.Angle;
                    _uow.CameraSettingRepository.Add(cameraSetting);
                    if (await _uow.SaveAsync() <= 0)
                    {
                        throw new Exception("Insert to [camera_setting] fails");
                    }

                }
                // insert camera config to [camera_configuration]
                CameraConfiguration cameraConfiguration = new CameraConfiguration()
                {
                    CameraId = camera.Id,
                    CameraSettingId = cameraSetting.Id,
                    ConnectionUrl = param.ConnectionUrl
                };
                _uow.CameraConfigurationRepository.Add(cameraConfiguration);
                return await _uow.SaveAsync() > 0
                    ? _mapper.Map<CameraDto>(camera)
                    : throw new Exception("Insert to [camera_configuration] fails");

            }
            else
            {
                throw new Exception("Insert to [camera] fails");
            }
        }

        public async Task<CameraDto> DeleteCamera(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Param is null");
            }
            CameraConfiguration cameraConfiguration = await _uow.CameraConfigurationRepository.GetFirst(filter: el => el.CameraId == id);
            _uow.CameraConfigurationRepository.Delete(cameraConfiguration);
            if (await _uow.SaveAsync() > 0)
            {
                Camera camera = await _uow.CameraRepository.GetFirst(filter: el => el.Id == id);
                _uow.CameraRepository.Delete(camera);
                if (await _uow.SaveAsync() > 0)
                {
                    return _mapper.Map<CameraDto>(camera);
                }
            }
            throw new Exception("Delete Camera fails");
        }

        public async Task<IEnumerable<CameraDto>> GetAllCamera(PagingRequestParam param)
        {
            IEnumerable<Camera> listCamera = await _uow.CameraRepository.Get(pageIndex: param.PageIndex, pageSize: param.PageSize);
            return _mapper.Map<IEnumerable<CameraDto>>(listCamera);
        }

        public async Task<CameraDto> UpdateCamera(CameraRequestParam param)
        {
            // add camera to [camera]
            Camera camera = new Camera()
            {
                Id = param.Id,
                Name = param.Name,
                AreaId = param.AreaId,
                Status = param.Status,
            };
            _uow.CameraRepository.Update(camera);
            // if insert success
            if (await _uow.SaveAsync() > 0)
            {
                CameraSetting cameraSetting = new CameraSetting()
                {
                    Id = param.CameraSettingId
                };
                // check if camera-settings is referenced
                if (param.CameraSettingId == 0)
                {
                    //insert setting to [camera_setting]
                    cameraSetting.Height = param.Height;
                    cameraSetting.Angle = param.Angle;
                    _uow.CameraSettingRepository.Add(cameraSetting);
                    if (await _uow.SaveAsync() <= 0)
                    {
                        throw new Exception("Insert to [camera_setting] fails");
                    }
                }
                // update camera config to [camera_configuration]
                CameraConfiguration cameraConfiguration = new CameraConfiguration()
                {
                    CameraId = camera.Id,
                    CameraSettingId = cameraSetting.Id,
                    ConnectionUrl = param.ConnectionUrl
                };
                _uow.CameraConfigurationRepository.Update(cameraConfiguration);
                return await _uow.SaveAsync() > 0
                    ? _mapper.Map<CameraDto>(camera)
                    : throw new Exception("Update to [camera_configuration] fails");

            }
            else
            {
                throw new Exception("Update to [camera] fails");
            }

        }

        public async Task<CameraDto> GetDetailCamera(int id)
        {
            Camera camera = await _uow.CameraRepository.GetFirst(
                filter: el => el.Id == id,
                includeProperties: "Area");
            //,CameraConfigurations,CameraConfigurations.CameraSetting
            return _mapper.Map<CameraDto>(camera);
        }

        public async Task<bool> UpdateStatusCamera(CameraStatus cameraUpdate)
        {
            Camera camera = await _uow.CameraRepository.GetById(cameraUpdate.Id);
            if (camera != null)
            {
                camera.Status = cameraUpdate.Status;
                _uow.CameraRepository.Update(camera);
                return await _uow.SaveAsync() > 0
                    ? true
                    : throw new Exception("Update Camera Status fails");
            }
            throw new Exception("Update Camera Status fails");
        }
    }
}
