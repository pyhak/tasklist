using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using ToDo2.Data;
using ToDo2.Core.Models;
using Xunit;
using Moq;
using System.Linq;
using EntityFrameworkCoreMock;
using ToDo2.Business;
using ToDo2.Repo;

namespace ToDo2.Tests
{
    public class UnitTest1
    {
        [Fact]
        [System.Obsolete]
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
            Assert.Equal(1, repo.GetAll().Count());
            Assert.Equal("üks täsk", savedTask.Description);
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
