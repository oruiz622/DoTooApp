using DoTooApp.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using DoTooApp.Views;

namespace DoTooApp.ViewModels
{
    public class TodoItemViewModel : ViewModel
    {
        public TodoItemViewModel(TodoItem item) => Item = item;

        public event EventHandler ItemStatusChanged;
        public TodoItem Item { get; set; }
        public string StatusText => Item.Completed ? "Reactivate" : "Completed";

        public ICommand AddItem => new Command(async () =>
        {
            var itemView = Resolver.Resolve<ItemView>();
            await Navigation.PushAsync(itemView);
        });

        public ICommand ToggleCommand => new Command((arg) =>
        {
            Item.Completed = !Item.Completed;
            ItemStatusChanged?.Invoke(this, new EventArgs());
        }); 
    }
}
