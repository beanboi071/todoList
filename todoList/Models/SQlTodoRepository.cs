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

        public Todo DeleteTask(Todo task)
        {
            
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

        public Todo UpdateTask(int id, Todo newTask)
        {
            var oldTask = context.ToDoList.Find(id);
            oldTask.Task = newTask.Task;
            oldTask.IsCompleted = newTask.IsCompleted;
            context.SaveChanges();
            return oldTask;
        }
    }
}
