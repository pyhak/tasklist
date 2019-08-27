using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo2.Business;
using ToDo2.Data;
using ToDo2.Core.Models;
using System.Web.Http.Cors;

namespace ToDo2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private IToDoService<Core.Models.Task> _service;

        public TaskController(IToDoService<Core.Models.Task> service)
        {
            _service = service;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Core.Models.Task> Get()
        {
            return _service.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Core.Models.Task> Get(int id)
        {
            return _service.GetById(id);
        }
        
        [HttpPost]
        public IEnumerable<Core.Models.Task> Post([FromBody] Core.Models.Task task)
        {

            _service.Add(task);
            return _service.GetAll();
        }
        
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Core.Models.Task task)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
