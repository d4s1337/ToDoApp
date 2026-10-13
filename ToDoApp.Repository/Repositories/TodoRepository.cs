using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;
using ToDoApp.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Repository.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Todo todo)
        {
            todo.CreatedDate = DateTime.Now;
            await _dbContext.Todos.AddAsync(todo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await _dbContext.Todos.FindAsync(id);
            if (todo is not null)
            {
                _dbContext.Todos.Remove(todo);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _dbContext.Todos
                .AsNoTracking()
                .OrderByDescending(item => item.CreatedDate)
                .ToListAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _dbContext.Todos.FindAsync(id);
        }

        public async Task UpdateAsync(Todo todo)
        {
            var existingTodo = await _dbContext.Todos.FindAsync(todo.Id);
            if (existingTodo is not null)
            {
                existingTodo.Title = todo.Title;
                existingTodo.Description = todo.Description;
                existingTodo.IsCompleted = todo.IsCompleted;
                existingTodo.DueDate = todo.DueDate;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}