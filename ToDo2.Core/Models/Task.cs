using System;

namespace Tasklist.Core.Models
{
    public class Task : BaseEntity
    {
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
