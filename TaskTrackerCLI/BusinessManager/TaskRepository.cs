using Models;
using Models.Interfaces;

namespace BusinessManager
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ITaskDataAccess _dataAccess;

        public TaskRepository(ITaskDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<UserTask> AddTask(string description)
        {
            UserTask newTask = new UserTask()
            {
                Description = description,
                CreatedAt = DateTime.Now,
                Status = Constants.ToDo,
                UpdateAt = DateTime.Now,
                Id = 0
            };

            return await _dataAccess.CreateUserTaskAsync(newTask);
        }

        public async Task<bool> DeleteTask(int id)
        {
            return await _dataAccess.DeleteUserTaskAsync(id);
        }

        public async Task<List<UserTask>> GetAllTasks()
        {
            return await _dataAccess.GetUserTaskList();
        }

        public async Task<List<UserTask>> GetTasksByStatus(string status)
        {
            return await _dataAccess.GetUserTaskByStatus(status);
        }

        public async Task<UserTask?> UpdateTask(int id, string description, string status)
        {
            UserTask userTask = new UserTask()
            {
                Id = id,
                Description = description,
                Status = status
            };

            return await _dataAccess.UpdateTaskAsync(userTask);
        }
    }
}
