using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;
namespace ToDoApp.Repository.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public Task AddAsync(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Todo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Todo>> GetAllSync()
        {
            return new List<Todo> {new Todo {Id = 1,
                Title = "Sample Todo",      
                Description = "This is a sample todo item.",
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Now,
                IsCompleted = false}
                                 };
        }

        public Task<Todo?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}