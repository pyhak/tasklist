using Microsoft.EntityFrameworkCore;
using Tasklist.Data;
using Tasklist.Core.Models;
using Xunit;
using Tasklist.Repo;

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
                Id = 1,
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
            Task task = new Task()
            {
                Id = 1,
                Description = "üks täsk",
                Status = true
            };
            Task savedTask = repo.Insert(task);
            var desc = "Uuus kirjeldus";
            savedTask.Description = desc;
            repo.Update(savedTask);
            Assert.Equal(desc, repo.Get(1).Description);
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
