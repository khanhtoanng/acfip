﻿using ACFIP.Data.Dtos;
using ACFIP.Data.Dtos.CameConfiguration;
using ACFIP.Data.Dtos.Camera;
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
        private readonly IMapper _mapper;
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
                GroupId = param.GroupId,
                ConnectionString = param.ConnectionString
            };
            _uow.CameraRepository.Add(camera);
            // if insert success
            if (await _uow.SaveAsync() > 0)
            {
                CameraConfiguration cameraConfiguration = new CameraConfiguration();
                // check if camera-configs is not referenced
                if (param.ConfigId == null || param.ConfigId == 0)
                {
                    //insert configuration to [camera_configuration]
                    cameraConfiguration.Height = param.Height;
                    cameraConfiguration.Angle = param.Angle;
                    _uow.CameraConfigurationRepository.Add(cameraConfiguration);
                    if (await _uow.SaveAsync() <= 0)
                    {
                        throw new Exception("Insert to [camera_configuration] fails");
                    }
                }
                else
                {
                    cameraConfiguration = await _uow.CameraConfigurationRepository.GetById(param.ConfigId);
                }
                // update camera with config id in request param
                camera.ConfigId = cameraConfiguration.Id;
                _uow.CameraRepository.Update(camera);
                return await _uow.SaveAsync() > 0
                            ? _mapper.Map<CameraDto>(camera)
                            : throw new Exception("Update to [camera] fails");
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
            camera.GroupId = null;
            camera.ConfigId = null;
            _uow.CameraRepository.Update(camera);
            return await _uow.SaveAsync() > 0 ? _mapper.Map<CameraDto>(camera) : throw new Exception("Delete to [camera] fails");
        }

        public async Task<IEnumerable<CameraDto>> GetAllCamera(bool isActive)
        {
            IEnumerable<Camera> listCamera = await _uow.CameraRepository
                        .Get(filter: el => el.IsActive == isActive & !el.DeletedFlag && el.GroupId != null, includeProperties: "Config,GroupCamera,GroupCamera.Area");
            return _mapper.Map<IEnumerable<CameraDto>>(listCamera);
        }

        public async Task<CameraDto> UpdateCamera(CameraUpdateParam param)
        {
            // get camera by id
            Camera camera = await _uow.CameraRepository.GetById(param.Id);
            camera.Name = param.Name;
            camera.IsActive = param.IsActive;
            camera.GroupId = param.GroupId;
            camera.ConnectionString = param.ConnectionString;
            _uow.CameraRepository.Update(camera);

            // if update success
            if (await _uow.SaveAsync() > 0)
            {
                CameraConfiguration cameraConfiguration = new CameraConfiguration();
                // check if camera-configs is not referenced
                if (param.ConfigId == null || param.ConfigId == 0)
                {
                    //insert configuration to [camera_configuration]
                    cameraConfiguration.Height = param.Height;
                    cameraConfiguration.Angle = param.Angle;
                    _uow.CameraConfigurationRepository.Add(cameraConfiguration);
                    if (await _uow.SaveAsync() <= 0)
                    {
                        throw new Exception("Insert to [camera_configuration] fails");
                    }
                }
                else
                {
                    cameraConfiguration = await _uow.CameraConfigurationRepository.GetById(param.ConfigId);
                    if (cameraConfiguration.Id == 0) 
                    {
                        throw new Exception("Can not find Id Configuration");
                    }
                }
               
                // update camera with config id in request param
                camera.ConfigId = cameraConfiguration.Id;
                _uow.CameraRepository.Update(camera);

                // get Area
                Data.Models.GroupCamera groupCamera = await _uow.GroupCameraRepository.GetFirst(filter: el => el.Id == camera.GroupId);
                return await _uow.SaveAsync() > 0
                            ? _mapper.Map<CameraDto>(camera)
                            : throw new Exception("Update to [camera] fails");
            }
            else
            {
                throw new Exception("Update to [camera] fails");
            }

        }

        public async Task<CameraDto> GetDetailCamera(int id)
        {
            return _mapper.Map<CameraDto>(await _uow.CameraRepository.GetFirst(
                filter: el => el.Id == id,
                includeProperties: "GroupCamera,GroupCamera.Area,Config"));
        }

        public async Task<CameraDto> UpdateStatusCamera(int id,CameraActivationParam cameraUpdate)
        {
            Camera camera = await _uow.CameraRepository.GetById(id);
            if (camera != null)
            {
                camera.IsActive = cameraUpdate.IsActive;
                _uow.CameraRepository.Update(camera);
                return await _uow.SaveAsync() > 0
                    ? _mapper.Map<CameraDto>(camera)
                    : throw new Exception("Update Camera Status Active fails");
            }
            return null;
        }
    }
}