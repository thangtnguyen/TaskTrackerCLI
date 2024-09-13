namespace Models.Interfaces
{
    public interface ITaskBusinessManager
    {
        int AddTask(string description);
        bool UpdateTaskDescription(int taskId, string description);
        bool DeleteTask(int taskId);
        bool UpdateTaskStatus(int taskId, string status);
        List<UserTask> GetTaskList();
        List<UserTask> GetTaskListByStatus(string status);
    }
}
