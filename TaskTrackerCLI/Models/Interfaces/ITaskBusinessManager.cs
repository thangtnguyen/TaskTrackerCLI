namespace Models.Interfaces
{
    public interface ITaskBusinessManager
    {
        Task<int> AddTask(string description);
        Task<bool> UpdateTaskDescription(int taskId, string description);
        Task<bool> DeleteTask(int taskId);
    }
}
