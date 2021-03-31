using System;
using System.Collections.Generic;
using System.Text;

namespace ACFIP.Data.Dtos.ViolationCase
{
    public class ViolationCaseBase
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string VideoUrl { get; set; }
        public int Status { get; set; }
        public bool IsView { get; set; }
        public string FileName { get; set; }

    }
}
