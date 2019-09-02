using System;
using System.Collections.Generic;
using System.Text;

namespace Tasklist.Core.Models
{
    public class BaseEntity
    {

        public int Id { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
