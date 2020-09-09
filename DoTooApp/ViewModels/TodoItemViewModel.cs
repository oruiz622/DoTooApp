using DoTooApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoTooApp.ViewModels
{
    public class TodoItemViewModel : ViewModel
    {
        public TodoItemViewModel(TodoItem item) => Item = item;

        public event EventHandler ItemStatusChanged; 
        public TodoItem Item { get; set; }
        public string StatusText => Item.Completed ? "Reactivate" : "Completed";
    }
}
