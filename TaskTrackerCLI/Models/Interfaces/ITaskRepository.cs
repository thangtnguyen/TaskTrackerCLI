namespace Models.Interfaces
{
    public interface ITaskRepository
    {
        Task<UserTask> AddTask(string description);
        Task<UserTask?> UpdateTaskDescription(int id, string description);
        Task<bool> DeleteTask(int id);
    }
}
