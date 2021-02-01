using ACFIP.Data.Dtos.ViolationCase;
using ACFIP.Data.Dtos.ViolationType;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.ViolationCaseType
{
    public class ViolationCaseTypeDto
    {
        public int ViolationTypeId { get; set; }
        public int ViolationCaseId { get; set; }
        public virtual ViolationCaseDto ViolationCase { get; set; }
        public virtual ViolationTypeDto ViolationType { get; set; }
    }
}
