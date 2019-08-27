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
        public void PassingTestGetAsync()
        {
            //var options = new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase("ToDoDB").Options;
            //var db = new ApiContext(options);
            var todo = new Task { Id = 1, Description = "new Todo" };
            var todos = new[] { new Task { Id = 1, Description = "new Todo" } };
            Mock<IRepository<Task>> mockRepository = new Mock<IRepository<Task>>();
            mockRepository.Setup(mr => mr.Get(
                It.IsAny<int>())).Returns((int i) => todos.Where(
                x => x.Id == i).Single());
            var repo = mockRepository.Object;
            repo.Insert(todo);
            Task task = repo.Get(1);
            
            Assert.NotNull(task);
        }
    }
}
