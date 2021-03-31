﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ACFIP.Data.Dtos.Area;
using ACFIP.Data.Dtos.CameConfiguration;
using ACFIP.Data.Dtos.ViolationCase;

namespace ACFIP.Data.Dtos.Camera
{
    public class CameraDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool DeletedFlag { get; set; }
        public string ConnectionString { get; set; }
        public int? LocationId { get; set; }
        public string LocationDescription { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int? ConfigId { get; set; }
        public float Height { get; set; }
        public float Angle { get; set; }
        public int NumberOfViolationsInDay { get; set; }
        public List<ViolationCaseDto> ViolationCases { get; set; }

    }
}
