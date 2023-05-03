namespace todoList.Models
{
    public interface IToDoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo Gettask(int id);
        Todo AddTask(Todo task);
        Todo UpdateTask(Todo newTask);
        Todo DeleteTask(int id);
    }
}
