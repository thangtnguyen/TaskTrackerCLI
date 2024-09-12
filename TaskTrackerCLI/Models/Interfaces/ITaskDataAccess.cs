namespace Models.Interfaces
{
    public interface ITaskDataAccess
    {
        Task<UserTask> CreateUserTaskAsync(UserTask userTask);
        Task<UserTask?> UpdateDescriptionUserTaskAsync(int id, string description);
        Task<UserTask?> UpdateStatusUserTask(int id, string status);
        Task<bool> DeleteUserTaskAsync(int id);
        Task<List<UserTask>> GetUserTaskList();
        Task<List<UserTask>> GetUserTaskByStatus(string status);
    }
}
