using System;

namespace ToDo2.Core.Models
{
    public class Task : BaseEntity
    {
        public string Description { get; set; }
        public Boolean Status { get; set; }
    }
}
