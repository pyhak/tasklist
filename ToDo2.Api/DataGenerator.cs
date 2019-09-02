using System;
using Tasklist.Core.Models;
using Tasklist.Data;

namespace Tasklist
{
    public class DataGenerator
    {
        [Obsolete]
        public static void Initialize(ApiContext context)
        {
            
            var task = new Tasklist.Core.Models.Task { Id = new Guid(), Description = "1. todo", ModifiedOnUtc = DateTime.Now};
            context.Tasks.Add(task);
            context.SaveChanges();
        }
    }
}
