using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.Services;

namespace ToDoApp.Service.Services
{
    public class TodoServices : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoServices(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _todoRepository.GetAllAsync();
        }

        public Task AddAsync(Todo todo)
        {
            return _todoRepository.AddAsync(todo);
        }

        public Task DeleteAsync(int id)
        {
            return _todoRepository.DeleteAsync(id);
        }



        public Task<Todo?> GetByIdAsync(int id)
        {
            return _todoRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Todo todo)
        {
            return _todoRepository.UpdateAsync(todo);
        }
    }


}