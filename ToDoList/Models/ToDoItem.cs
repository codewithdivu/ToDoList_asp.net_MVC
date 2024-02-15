using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Task is required")]
        [StringLength(100, ErrorMessage = "Task must be between 1 and 100 characters", MinimumLength = 5)]
        public string task { get; set; }

        public bool IsCompleted { get; set; }
    }
}
