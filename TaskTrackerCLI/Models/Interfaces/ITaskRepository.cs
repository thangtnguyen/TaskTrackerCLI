namespace Models.Interfaces
{
    public interface ITaskRepository
    {
        Task<UserTask> AddTask(string description);        
        Task<bool> DeleteTask(int id);        
        Task<UserTask?> UpdateTask(int id, string description, string status);
        Task<List<UserTask>> GetAllTasks();
        Task<List<UserTask>> GetTasksByStatus(string status);
    }
}
