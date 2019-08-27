using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo2.Core.Models
{
    public class BaseEntity
    {

        public int Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
