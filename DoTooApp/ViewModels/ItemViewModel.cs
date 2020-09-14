﻿using DoTooApp.Models;
using DoTooApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DoTooApp.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private readonly TodoItemRepository repository;

        public TodoItem Item { get; set; }

        public ItemViewModel(TodoItemRepository repository)
        {
            this.repository = repository;
            Item = new TodoItem() { Due = DateTime.Now.AddDays(1) };
        }

        public ICommand Save => new Command(async () =>
        {
            await repository.AddOrUpdate(Item);
            await Navigation.PopAsync();
        });
    }
}
