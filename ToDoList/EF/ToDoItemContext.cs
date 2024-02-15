using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToDoList.Models;

namespace ToDoList.EF
{
    public class ToDoItemContext : DbContext
    {
        public ToDoItemContext() : base("ToDoItem")
        {

        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}