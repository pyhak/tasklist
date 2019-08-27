using System;
using System.Collections.Generic;
using ToDo2.Business;
using ToDo2.Data;
using ToDo2.Core.Models;

namespace ToDo2
{
    public class DataGenerator
    {
        
        public static void Initialize(ApiContext context)
        {
            var todo = new Task { Id = 1, Description = "1. todo", ModifiedOn = DateTime.Now };
            context.Tasks.Add(todo);
            context.SaveChanges();
        }
    }
}
