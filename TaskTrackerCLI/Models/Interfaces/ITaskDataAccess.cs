namespace Models.Interfaces
{
    public interface ITaskDataAccess
    {
        UserTask CreateUserTask(UserTask userTask);        
        bool DeleteUserTask(int id);
        List<UserTask> GetUserTaskList();
        List<UserTask> GetUserTaskByStatus(string status);
        UserTask? UpdateTask(UserTask userTask);
    }
}
