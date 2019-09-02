using System;
using System.Collections.Generic;
using Tasklist.Business;
using Tasklist.Data;
using Tasklist.Core.Models;

namespace Tasklist
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
