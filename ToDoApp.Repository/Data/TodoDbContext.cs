using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Models;

namespace ToDoApp.Repository.Data;

public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos => Set<Todo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.ToTable("Todos");
            entity.HasKey(todo => todo.Id);
            entity.Property(todo => todo.Title).IsRequired().HasMaxLength(120);
            entity.Property(todo => todo.Description).HasMaxLength(500);
        });
    }
}