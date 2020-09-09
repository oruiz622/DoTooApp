﻿using DoTooApp.Repositories;
using System.Threading.Tasks;

namespace DoTooApp.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly TodoItemRepository repository;

        public MainViewModel(TodoItemRepository repository)
        {
            this.repository = repository;
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
        }
    }
}
