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

        public async Task<int> AddTask(string description)
        {
            var userTask = await _taskRepository.AddTask(description);
            return userTask.Id;
        }

        public async Task<bool> UpdateTaskDescription(int taskId, string description)
        {
            var userTask = await _taskRepository.UpdateTask(taskId, description, string.Empty);
            return userTask != null;
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            return await _taskRepository.DeleteTask(taskId);
        }

        public async Task<bool> UpdateTaskStatus(int taskId, string status)
        {
            var userTask = await _taskRepository.UpdateTask(taskId, string.Empty, status);
            return userTask != null;
        }

        public async Task<List<UserTask>> GetTaskList()
        {
            return await _taskRepository.GetAllTasks();
        }

        public async Task<List<UserTask>> GetTaskListByStatus(string status)
        {
            if (IsStatusValid(status))
            {
                return await _taskRepository.GetTasksByStatus(status);
            }

            return new List<UserTask>();
        }

        private bool IsStatusValid(string status)
        {
            return status == Constants.InProgress || status == Constants.ToDo || status == Constants.Done;
        }
    }
}
