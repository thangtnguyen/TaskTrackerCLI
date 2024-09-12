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
            var userTask = await _taskRepository.UpdateTaskDescription(taskId, description);
            return userTask != null;
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            return await _taskRepository.DeleteTask(taskId);
        }
    }
}
