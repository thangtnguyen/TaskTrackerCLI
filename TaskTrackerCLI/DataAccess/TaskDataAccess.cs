﻿using Microsoft.Extensions.Options;
using Models;
using Models.Interfaces;
using Newtonsoft.Json;


namespace DataAccess
{
    public class TaskDataAccess : ITaskDataAccess
    {
        private readonly FileDataSourceOptions _fileDataSourceOptions;
        private readonly string _filePath;

        public TaskDataAccess(IOptions<FileDataSourceOptions> fileDataSourceOptions) 
        {
            _fileDataSourceOptions = fileDataSourceOptions.Value;
            _filePath = Path.Combine(_fileDataSourceOptions.FilePath, _fileDataSourceOptions.FileName);
        }

        public UserTask CreateUserTask(UserTask userTask)
        {
            // Get new User Task Id
            userTask.Id = GetTaskId();

            //Insert new user task
            var userTaskList = GetUserTaskList();
            if (userTaskList != null)
            {
                userTaskList.Add(userTask);
            }

            UpdateToFile(userTaskList);

             return userTask;
        }

        private void UpdateToFile(List<UserTask> userTaskList)
        {
            if (userTaskList != null) 
            {
                if (CreateFileifNotExist())
                {
                    string updatedUserTasks =  JsonConvert.SerializeObject(userTaskList);
                    File.WriteAllText(_filePath, updatedUserTasks);
                }
            }
        }

        private bool CreateFileifNotExist()
        {
            try
            {
                // Check if the file exists
                if (!File.Exists(_filePath))
                {
                    // Create the file if it does not exist
                    using (FileStream fs = File.Create(_filePath))
                    {
                        Console.WriteLine($"File {_fileDataSourceOptions.FileName} created successfully.");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File {_fileDataSourceOptions.FileName} creation failed. Error - " + ex.Message);
                return false;
            }
        }

        private int GetTaskId()
        {
            if (File.Exists(_filePath))
            {
                string tasksFromJsonFileInString = File.ReadAllText(_filePath);
                if (!string.IsNullOrEmpty(tasksFromJsonFileInString))
                {
                    try
                    {
                        var userTasks = JsonConvert.DeserializeObject<List<UserTask>>(tasksFromJsonFileInString);
                        if (userTasks != null && userTasks.Count > 0)
                        {
                            return userTasks.OrderBy(x => x.Id).Last().Id + 1;
                        }
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex);
                    }
                    
                }
            }

            return 1;
        }

        public bool DeleteUserTask(int id)
        {
            var userTaskList = GetUserTaskList();
            if (userTaskList != null && userTaskList.Count > 0)
            {
                var existingTask = userTaskList.FirstOrDefault(p => p.Id == id);
                if (existingTask != null)
                {
                    userTaskList.Remove(existingTask);
                    UpdateToFile(userTaskList);

                    return true;
                }
            }

            return false;
        }

        public List<UserTask> GetUserTaskByStatus(string status)
        {
            var allTasks = GetUserTaskList();

            return allTasks.FindAll(p => p.Status == status);
        }

        public List<UserTask> GetUserTaskList()
        {

            if (File.Exists(_filePath))
            {

                string tasksFromJsonFileInString = File.ReadAllText(_filePath);
                if (!string.IsNullOrEmpty(tasksFromJsonFileInString))
                {
                    try
                    {
                        var result = JsonConvert.DeserializeObject<List<UserTask>>(tasksFromJsonFileInString);
                        return result ?? new List<UserTask>();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }

            return new List<UserTask>();
        }

        public UserTask? UpdateTask(UserTask userTask)
        {
            UserTask? result = null;

            var userTaskList = GetUserTaskList();
            if (userTaskList != null && userTaskList.Count > 0)
            {
                result = userTaskList.FirstOrDefault(p => p.Id == userTask.Id);
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(userTask.Description))
                    {
                        result.Description = userTask.Description;
                    }
                    if (!string.IsNullOrEmpty(userTask.Status))
                    {
                        result.Status = userTask.Status;
                    }
                    result.UpdateAt = DateTime.Now;
                    
                    UpdateToFile(userTaskList);

                    return result;
                }
            }

            return result;
        }
    }
}
