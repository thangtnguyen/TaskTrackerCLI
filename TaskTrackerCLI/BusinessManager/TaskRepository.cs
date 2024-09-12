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

        public async Task<UserTask?> UpdateTaskDescription(int id, string description)
        {
            return await _dataAccess.UpdateDescriptionUserTaskAsync(id, description);
        }
    }
}
