namespace Models.Interfaces
{
    public interface ITaskBusinessManager
    {
        Task<int> AddTask(string description);
        Task<bool> UpdateTaskDescription(int taskId, string description);
        Task<bool> DeleteTask(int taskId);
        Task<bool> UpdateTaskStatus(int taskId, string status);
        Task<List<UserTask>> GetTaskList();
        Task<List<UserTask>> GetTaskListByStatus(string status);
    }
}
