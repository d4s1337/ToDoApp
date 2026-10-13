using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Models;
using ToDoApp.Core.Services;

namespace ToDoApp.UI.Controllers;

public class TodoController : Controller
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _todoService.GetAllAsync());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(Todo todo)
    {
        if (!string.IsNullOrWhiteSpace(todo.Title))
        {
            await _todoService.AddAsync(todo);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _todoService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}