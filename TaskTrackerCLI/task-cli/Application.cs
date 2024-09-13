using Models;
using Models.Interfaces;

namespace task_cli
{
    public class Application : IApplication
    {
        public ITaskBusinessManager _taskBusinessManager { get; set; }
        
        public Application(ITaskBusinessManager taskBusinessManager)
        {
            _taskBusinessManager = taskBusinessManager;
        }

        public void HandleBusiness(string[] arguments)
        {
            // Parse command from console paramters
            if (arguments == null || arguments.Length == 0)
            {
                Console.WriteLine("Program needs command (add, update, delete, mark-in-progress, mark-done, list)");
            }
            else
            {
                int taskId;
                switch (arguments[0])
                {                    
                    case "add":                        
                        taskId = _taskBusinessManager.AddTask(arguments[1]);
                        Console.WriteLine("Task added successfully (ID: {0})", taskId);
                        break;
                    case "update":
                        if (int.TryParse(arguments[1], out taskId))
                        {
                            bool isSuccess = _taskBusinessManager.UpdateTaskDescription(taskId, arguments[2]);
                            if (isSuccess)
                            {
                                Console.WriteLine("Task (ID: {0}) is updated successfully.", arguments[1]);
                            }
                            else
                            {
                                Console.WriteLine("Task (ID: {0}) is not updated.", arguments[1]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid parameters: {0}. Please use: task-cli update <task id as int> \"<update description>\"", arguments[1]);
                        }
                        break;
                    case "delete":
                        if (int.TryParse(arguments[1], out taskId))
                        {
                            bool result = _taskBusinessManager.DeleteTask(taskId);
                            if (result)
                            {
                                Console.WriteLine("Task (ID: {0}) is deleted.", taskId);
                            }
                            else
                            {
                                Console.WriteLine("Task (ID: {0}) is not deleted.", taskId);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid parameters: {0}. Please use: task-cli delete <task id as int>", arguments[1]);
                        }
                        break;
                    case "mark-in-progress":
                        if (int.TryParse(arguments[1], out taskId))
                        {
                            var result = _taskBusinessManager.UpdateTaskStatus(taskId, Constants.InProgress);
                            if ( result)
                            {
                                Console.WriteLine("Task {0} is marked in-progress.", taskId);
                            }
                            else
                            {
                                Console.WriteLine("Task {0} is failed to mark in-progress", taskId);
                            }
                        }                        
                        else
                        {
                            Console.WriteLine("Invalid parameters: {0}. Please use: task-cli mark-in-progress <task id as int>", arguments[1]);
                        }
                        break;
                    case "mark-done":
                        if (int.TryParse(arguments[1], out taskId))
                        {
                            var result = _taskBusinessManager.UpdateTaskStatus(taskId, Constants.Done);
                            if (result)
                            {
                                Console.WriteLine("Task {0} is marked done.", taskId);
                            }
                            else
                            {
                                Console.WriteLine("Task {0} is failed to mark done", taskId);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid parameters: {0}. Please use: task-cli mark-done <task id as int>", arguments[1]);
                        }
                        break;
                    case "list":
                        if (arguments.Count() == 1)
                        {
                            DisplayTasks(_taskBusinessManager.GetTaskList());
                        }
                        else if (arguments.Count() == 2)
                        {
                            DisplayTasks(_taskBusinessManager.GetTaskListByStatus(arguments[1]));
                        }
                        else
                        {
                            Console.WriteLine("Invalid parameters. Please use: task-cli list <task status> or task-cli list");
                        }
                        break; 
                    default:
                        Console.WriteLine("Program needs command (add, update, delete, mark-in-progress, mark-done, list)");
                        break;
                }
            }
        }

        private void DisplayTasks(List<UserTask> userTasks)
        {
            if (userTasks != null && userTasks.Count > 0)
            {
                Console.WriteLine("The task list:");
                Console.WriteLine("ID\t\tDescription\t\tStatus");
                foreach (var userTask in userTasks)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", userTask.Id, userTask.Description, userTask.Status);
                }
            }
        }
    }
}
 