namespace Models.Interfaces
{
    public interface ITaskDataAccess
    {
        Task<UserTask> CreateUserTaskAsync(UserTask userTask);        
        Task<bool> DeleteUserTaskAsync(int id);
        Task<List<UserTask>> GetUserTaskList();
        Task<List<UserTask>> GetUserTaskByStatus(string status);
        Task<UserTask?> UpdateTaskAsync(UserTask userTask);
    }
}
