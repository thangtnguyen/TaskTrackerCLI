namespace Models.Interfaces
{
    public interface ITaskRepository
    {
        UserTask AddTask(string description);        
        bool DeleteTask(int id);        
        UserTask? UpdateTask(int id, string description, string status);
        List<UserTask> GetAllTasks();
        List<UserTask> GetTasksByStatus(string status);
    }
}
