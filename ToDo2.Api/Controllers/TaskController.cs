using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tasklist.Business;

namespace Tasklist.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITasklistService<Core.Models.Task> _service;

        public TaskController(ITasklistService<Core.Models.Task> service)
        {
            _service = service;
        }
        // GET api/values
        [HttpGet]
        public List<Core.Models.Task> Get()
        {
            var list = _service.GetAll();
            return list;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Core.Models.Task> Get(Guid id)
        {
            return _service.GetById(id);
        }
        
        [HttpPost]
        public List<Core.Models.Task> Post([FromBody] Core.Models.Task task)
        {
            if (task.Id == null) { 
                _service.Add(task);
            }
            else
            {
                _service.Edit(task);
            }
            return _service.GetAll();
        }
        
        
        [HttpPut("{task}")]
        public void Put([FromBody] Core.Models.Task task)
        {
            _service.Edit(task);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
