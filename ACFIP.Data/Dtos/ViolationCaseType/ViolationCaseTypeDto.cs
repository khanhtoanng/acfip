using ACFIP.Data.Dtos.ViolationCase;
using ACFIP.Data.Dtos.ViolationType;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.ViolationCaseType
{
    public class ViolationCaseTypeDto
    {
        public ViolationCaseDto Case { get; set; }
        public ViolationTypeDto Type { get; set; }
    }
}
