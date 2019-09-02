using Microsoft.EntityFrameworkCore;
using Tasklist.Data;
using Tasklist.Core.Models;
using Xunit;
using Tasklist.Repo;
using System;

namespace Tasklist.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTestGet()
        {
            IRepository<Task> repo = GetInMemoryTaskRepository();
            Task task = new Task()
            {
                Id = new Guid(),
                Description = "üks täsk",
                Status = true
            };

            Task savedTask = repo.Insert(task);
            Assert.NotNull(task);
            Assert.Single(repo.GetAll());
            Assert.Equal("üks täsk", savedTask.Description);
        }
        [Fact]
        public void CanUpdateTask()
        {
            IRepository<Task> repo = GetInMemoryTaskRepository();
            var guid = new Guid();
            Task task = new Task()
            {
                Id = guid,
                Description = "üks täsk",
                Status = true
            };
            Task savedTask = repo.Insert(task);
            var desc = "Uuus kirjeldus";
            savedTask.Description = desc;
            repo.Update(savedTask);
            Assert.Equal(desc, repo.Get(guid).Description);
        }
        private IRepository<Task> GetInMemoryTaskRepository()
        {
            DbContextOptions<ApiContext> options;
            var builder = new DbContextOptionsBuilder<ApiContext>();
            builder.UseInMemoryDatabase("ToDoDB");
            options = builder.Options;
            ApiContext taskDataContext = new ApiContext(options);
            taskDataContext.Database.EnsureDeleted();
            taskDataContext.Database.EnsureCreated();
            return new Repository<Task>(taskDataContext);
        }

    }

}
