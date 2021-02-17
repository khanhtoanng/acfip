using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.CameConfiguration;
using ACFIP.Data.Dtos.Camera;
using ACFIP.Data.Dtos.CameraCamConfiguration;
using ACFIP.Data.Helpers;
using ACFIP.Data.Models;
using ACFIP.Data.Repository;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Services.CameraService
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

        public async Task<CameraDto> CreateCamera(CameraCreateParam param)
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
                CameraConfiguration cameraConfiguration = new CameraConfiguration()
                {
                    Id = param.CameraConfigId
                };
                // check if camera-configs is referenced
                if (cameraConfiguration.Id == 0)
                {
                    //insert setting to [camera_setting]
                    cameraConfiguration.Height = param.Height;
                    cameraConfiguration.Angle = param.Angle;
                    _uow.CameraConfigurationRepository.Add(cameraConfiguration);
                    if (await _uow.SaveAsync() <= 0)
                    {
                        throw new Exception("Insert to [camera_configuration] fails");
                    }
                }
                // insert camera config to [camera_camera_configuration]
                CameraCamConfig cameraCamConfiguration = new CameraCamConfig()
                {
                    CameraId = camera.Id,
                    ConfigId = cameraConfiguration.Id,
                    ConnectionString = param.ConnectionString
                };
                _uow.CameraCamConfigRepository.Add(cameraCamConfiguration);
                return await _uow.SaveAsync() > 0
                    ? _mapper.Map<CameraDto>(camera)
                    : throw new Exception("Insert to [camera_camera_configuration] fails");

            }
            else
            {
                throw new Exception("Insert to [camera] fails");
            }
        }

        //public async Task<CameraDto> DeleteCamera(int id)
        //{
        //    if (id == 0)
        //    {
        //        throw new ArgumentException("Param is null");
        //    }
        //    CameraConfiguration cameraConfiguration = await _uow.CameraConfigurationRepository.GetFirst(filter: el => el.CameraId == id);
        //    _uow.CameraConfigurationRepository.Delete(cameraConfiguration);
        //    if (await _uow.SaveAsync() > 0)
        //    {
        //        Camera camera = await _uow.CameraRepository.GetFirst(filter: el => el.Id == id);
        //        _uow.CameraRepository.Delete(camera);
        //        if (await _uow.SaveAsync() > 0)
        //        {
        //            return _mapper.Map<CameraDto>(camera);
        //        }
        //    }
        //    throw new Exception("Delete Camera fails");
        //}
        public async Task<CameraDto> DeleteCamera(int id)
        {
            Camera camera = await _uow.CameraRepository.GetFirst(filter: el => el.Id == id);
            camera.DeletedFlag = true;
            _uow.CameraRepository.Update(camera);
            return await _uow.SaveAsync() > 0 ? _mapper.Map<CameraDto>(camera) : throw new Exception("Delete to [camera] fails");
        }

        public async Task<IEnumerable<CameraDto>> GetAllCamera(CameraRequestParam param)
        {
            IEnumerable<Camera> listCamera = null;
            if (param.AreaId == 0)
            {
                listCamera = await _uow.CameraRepository
                        .Get(pageIndex: param.PageIndex, pageSize: param.PageSize, includeProperties: "Area");
            }
            else
            {
                listCamera = await _uow.CameraRepository
                        .Get(pageIndex: param.PageIndex, pageSize: param.PageSize,
                        filter: el => el.AreaId == param.AreaId, includeProperties: "Area");
            }
            return _mapper.Map<IEnumerable<CameraDto>>(listCamera);
        }

        public async Task<CameraDto> UpdateCamera(CameraUpdateParam param)
        {
            // get camera by id
            Camera camera = await _uow.CameraRepository.GetById(param.Id);
            camera.Name = param.Name;
            camera.Status = param.Status;
            camera.AreaId = param.AreaId;
            _uow.CameraRepository.Update(camera);

            // if insert success
            if (await _uow.SaveAsync() > 0)
            {
                CameraConfiguration cameraConfiguration = new CameraConfiguration()
                {
                    Id = param.CameraConfigId
                };
                // check if camera-configs is referenced
                if (cameraConfiguration.Id == 0)
                {
                    //insert setting to [camera_setting]
                    cameraConfiguration.Height = param.Height;
                    cameraConfiguration.Angle = param.Angle;
                    _uow.CameraConfigurationRepository.Add(cameraConfiguration);
                    if (await _uow.SaveAsync() <= 0)
                    {
                        throw new Exception("Insert to [camera_configuration] fails");
                    }
                }

                // update camera config to [camera_configuration]
                CameraCamConfig cameraCamConfiguration = await _uow.CameraCamConfigRepository
                    .GetFirst(filter: el => el.CameraId == camera.Id);
                cameraCamConfiguration.ConfigId = cameraConfiguration.Id;
                cameraCamConfiguration.ConnectionString = param.ConnectionString;
                _uow.CameraCamConfigRepository.Update(cameraCamConfiguration);

                // get Area
                Area area = await _uow.AreaRepository.GetFirst(filter: el => el.Id == camera.AreaId);

                return await _uow.SaveAsync() > 0
                    ? _mapper.Map<CameraDto>(camera)
                    : throw new Exception("Update to [camera_camera_configuration] fails");
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
            CameraCamConfig cameraCamConfig = await _uow.CameraCamConfigRepository.GetFirst(
                filter: el => el.CameraId == id, includeProperties: "Config");
            CameraDto result = _mapper.Map<CameraDto>(camera);
            result.CameraCamConfiguration = _mapper.Map<CameraCamConfigDto>(cameraCamConfig);
            return result;
        }

        public async Task<CameraDto> UpdateStatusCamera(CameraStatus cameraUpdate)
        {
            Camera camera = await _uow.CameraRepository.GetById(cameraUpdate.Id);
            if (camera != null)
            {
                camera.Status = cameraUpdate.Status;
                _uow.CameraRepository.Update(camera);
                return await _uow.SaveAsync() > 0
                    ? _mapper.Map<CameraDto>(camera)
                    : throw new Exception("Update Camera Status fails");
            }
            return null;
        }
    }
}
