using Microsoft.EntityFrameworkCore;
using todoList.Models;

namespace todoList.DB
{
    public class ToDoDbContext: DbContext
    {
        public ToDoDbContext(DbContextOptions <ToDoDbContext> options) : base(options) { }
        public DbSet<Todo> ToDoList { get; set; }
    }
}
