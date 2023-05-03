using Microsoft.EntityFrameworkCore;
using todoList.DB;

namespace todoList.Models
{
    public class SQlTodoRepository : IToDoRepository
    {
        private readonly ToDoDbContext context;
        public SQlTodoRepository(ToDoDbContext context)
        {
            this.context = context;
        }
        public Todo AddTask(Todo task)
        {
            context.Add(task);
            context.SaveChanges();
            return task;
        }

        public Todo DeleteTask(int id)
        {
            var task = context.ToDoList.Find(id);
            context.ToDoList.Remove(task);
            context.SaveChanges();
            return task;
        }

        public IEnumerable<Todo> GetAll()
        {
            return context.ToDoList;
        }

        public Todo Gettask(int id)
        {
            var task = context.ToDoList.Find(id);
            return task;
        }

        public Todo UpdateTask(Todo newTask)
        {
            context.Entry(newTask).State = EntityState.Modified;
            context.SaveChanges();
            return newTask;
        }
    }
}
