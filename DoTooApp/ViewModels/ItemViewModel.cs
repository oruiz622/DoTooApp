using DoTooApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoTooApp.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private readonly TodoItemRepository repository;

        public ItemViewModel(TodoItemRepository repository)
        {
            this.repository = repository;
        }
    }
}
