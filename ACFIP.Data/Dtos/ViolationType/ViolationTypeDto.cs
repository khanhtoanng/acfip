using System;
using System.Collections.Generic;
using System.Text;
using ACFIP.Data.Dtos.ViolationCase;
using ACFIP.Data.Dtos.ViolationCaseType;

namespace ACFIP.Data.Dtos.ViolationType
{
    public class ViolationTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ViolationCaseTypeDto> ViolationCaseTypes { get; set; }
    }
}
