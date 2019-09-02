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
            
            var task = new Tasklist.Core.Models.Task { Id = 1, Description = "1. todo", ModifiedOn = DateTime.Now};
            context.Tasks.Add(task);
            context.SaveChanges();
        }
    }
}
