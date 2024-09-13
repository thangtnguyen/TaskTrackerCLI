using Models;
using Models.Interfaces;

namespace BusinessManager
{
    public class TaskBusinessManager : ITaskBusinessManager
    {
        public ITaskRepository _taskRepository { get; set; }
        public TaskBusinessManager(ITaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;
        }

        public int AddTask(string description)
        {
            var userTask = _taskRepository.AddTask(description);
            return userTask.Id;
        }

        public bool UpdateTaskDescription(int taskId, string description)
        {
            var userTask = _taskRepository.UpdateTask(taskId, description, string.Empty);
            return userTask != null;
        }

        public bool DeleteTask(int taskId)
        {
            return _taskRepository.DeleteTask(taskId);
        }

        public bool UpdateTaskStatus(int taskId, string status)
        {
            var userTask = _taskRepository.UpdateTask(taskId, string.Empty, status);
            return userTask != null;
        }

        public List<UserTask> GetTaskList()
        {
            return _taskRepository.GetAllTasks();
        }

        public List<UserTask> GetTaskListByStatus(string status)
        {
            if (IsStatusValid(status))
            {
                return _taskRepository.GetTasksByStatus(status);
            }

            return new List<UserTask>();
        }

        private bool IsStatusValid(string status)
        {
            return status == Constants.InProgress || status == Constants.ToDo || status == Constants.Done;
        }
    }
}
