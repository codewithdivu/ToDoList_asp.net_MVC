using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.EF;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        ToDoItemContext db = new ToDoItemContext();
        public ActionResult Index()
        {
            var data = db.ToDoItems.ToList();
            return View(data);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(String text)
        {
            if (ModelState.IsValid)
            {
                ToDoItem toDoItem = new ToDoItem { task = text, IsCompleted = false };
                db.ToDoItems.Add(toDoItem);
                db.SaveChanges();
                TempData["create"] = "Task Created Successfully!";
                var data = db.ToDoItems.ToList();
                return PartialView("_TodoList", data);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            ToDoItem item = db.ToDoItems.Find(id);
            if (item != null)
            {
                db.ToDoItems.Remove(item);
                db.SaveChanges();
            }
            TempData["delete"] = "Task Deleted Successfully!";
            var data = db.ToDoItems.ToList();
            return PartialView("_TodoList", data);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult MarkCompleted(int id)
        {
            ToDoItem item = db.ToDoItems.Find(id);
            if (item != null)
            {
                if (item.IsCompleted == true)
                {
                    item.IsCompleted = false;
                    db.SaveChanges();
                }
                else
                {
                    item.IsCompleted = true;
                    db.SaveChanges();
                }
            }
            var data = db.ToDoItems.ToList();
            return PartialView("_TodoList", data);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string text)
        {
            ToDoItem item = db.ToDoItems.Find(id);
            if (item != null)
            {
                item.task = text;
                db.SaveChanges();
            }
            var data = db.ToDoItems.ToList();
            return PartialView("_TodoList", data);
        }
    }
}