using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Entities
{
    public class CourseGroup : BaseEntity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int Room { get; set; }
    }
}
