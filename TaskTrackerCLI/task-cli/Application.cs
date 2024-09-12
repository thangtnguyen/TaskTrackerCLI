using Models.Interfaces;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace task_cli
{
    public class Application : IApplication
    {
        public ITaskBusinessManager _taskBusinessManager { get; set; }
        
        public Application(ITaskBusinessManager taskBusinessManager)
        {
            _taskBusinessManager = taskBusinessManager;
        }

        public async Task HandleBusiness(string[] arguments)
        {
            Console.WriteLine("Hell World!");

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
                        taskId = await _taskBusinessManager.AddTask(arguments[1]);
                        Console.WriteLine("Task added successfully (ID: {0})", taskId);
                        break;
                    case "update":
                        if (int.TryParse(arguments[1], out taskId))
                        {
                            bool isSuccess = await _taskBusinessManager.UpdateTaskDescription(taskId, arguments[2]);
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
                            bool result = await _taskBusinessManager.DeleteTask(taskId);
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
                    case "list":
                    default:
                        Console.WriteLine("Program needs command (add, update, delete, mark-in-progress, mark-done, list)");
                        break;
                }
            }
        }
    }
}
 