using System;
using System.Collections.Generic;
using ToDo2.Core.Models;
using ToDo2.Data;

namespace ToDo2
{
    public class DataGenerator
    {
        [Obsolete]
        public static void Initialize(ApiContext context)
        {
            
            var task = new Task { Id = 1, Description = "1. todo", ModifiedOn = DateTime.Now};
            //context.Tasks.Add(task);
            //context.SaveChanges();
        }
    }
}
