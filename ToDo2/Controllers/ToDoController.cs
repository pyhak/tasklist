using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasklist.Business;
using Tasklist.Data;
using Tasklist.Core.Models;

namespace Tasklist.Controllers
{
    public class ToDoController : Controller
    {
        private IToDoService<Core.Models.Task> _service;
        public ToDoController(IToDoService<Core.Models.Task> service)
        {
            _service = service;
        }
        // GET: ToDo
        public ActionResult Index()
        {
            var allToDos = _service.GetAll();
            return View(allToDos);
        }

        // GET: ToDo/Details/5
        public ActionResult Details(Guid id)
        {
            var detail = _service.GetById(id);
            return View(detail);
        }

        // GET: ToDo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var task = new Core.Models.Task
                {
                    Description = collection["Name"].ToString(),
                    Status = false
                };
                _service.Add(task);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ToDo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var task = new Core.Models.Task
                {
                    Description = collection["Name"].ToString(),
                    Status = collection["Status"] == "true"
                };
                _service.Edit(task);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ToDo/Delete/5
        public ActionResult Delete(Guid id)
        {
            var task = _service.GetById(id);
            _service.Delete(task);
            return View();
        }

        // POST: ToDo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}