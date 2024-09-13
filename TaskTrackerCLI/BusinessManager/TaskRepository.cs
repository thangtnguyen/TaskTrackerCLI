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

        public UserTask AddTask(string description)
        {
            UserTask newTask = new UserTask()
            {
                Description = description,
                CreatedAt = DateTime.Now,
                Status = Constants.ToDo,
                UpdateAt = DateTime.Now,
                Id = 0
            };

            return _dataAccess.CreateUserTask(newTask);
        }

        public bool DeleteTask(int id)
        {
            return _dataAccess.DeleteUserTask(id);
        }

        public List<UserTask> GetAllTasks()
        {
            return _dataAccess.GetUserTaskList();
        }

        public List<UserTask> GetTasksByStatus(string status)
        {
            return _dataAccess.GetUserTaskByStatus(status);
        }

        public UserTask? UpdateTask(int id, string description, string status)
        {
            UserTask userTask = new UserTask()
            {
                Id = id,
                Description = description,
                Status = status
            };

            return _dataAccess.UpdateTask(userTask);
        }
    }
}
