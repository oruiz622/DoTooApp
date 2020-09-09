﻿using DoTooApp.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace DoTooApp.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private SQLiteAsyncConnection connection;

        public event EventHandler<TodoItem> OnItemAdded;
        public event EventHandler<TodoItem> OnItemUpdated;
        public event EventHandler<TodoItem> OnItemDeleted;

        public async Task<List<TodoItem>> GetItems()
        {
            await CreateConnection();
            return await connection.Table<TodoItem>().ToListAsync();
        }

        public async Task AddItem(TodoItem item)
        {
            await CreateConnection();
            await connection.InsertAsync(item);
            OnItemAdded?.Invoke(this, item);
        }

        public async Task UpdateItem(TodoItem item)
        {
            await CreateConnection();
            await connection.UpdateAsync(item);
            OnItemAdded?.Invoke(this, item);
        }

        public async Task DeleteItem(TodoItem item)
        {
            await CreateConnection();
            await connection.DeleteAsync(item);
            OnItemDeleted.Invoke(this, item);
        }

        public async Task AddOrUpdate(TodoItem item)
        {
            if (item.Id == 0)
            {
                await AddItem(item);
            }
            else
            {
                await UpdateItem(item);
            }
        }

        private async Task CreateConnection()
        {
            if (connection != null)
            {
                return;
            }

            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "TodoItemsDb.db");

            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<TodoItem>();

            if (await connection.Table<TodoItem>().CountAsync() == 0)
            {
                await connection.InsertAsync(new TodoItem()
                {
                    Title = "Welcome to DoTooApp",
                    Due = DateTime.Now
                });
            }
        }
    }
}