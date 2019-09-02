using System;
using System.Collections.Generic;
using System.Text;

namespace Tasklist.Core.Models
{
    public class BaseEntity
    {

        public Guid Id { get; set; }
        public DateTimeOffset ModifiedOnUtc { get; set; }
        public DateTimeOffset CreatedOnUtc { get; set; }
    }
}
