namespace todoList.Models
{
    public interface IToDoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo Gettask(int id);
        Todo AddTask(Todo task);
        Todo UpdateTask(int id, Todo newTask);
        Todo DeleteTask(int id);
    }
}
