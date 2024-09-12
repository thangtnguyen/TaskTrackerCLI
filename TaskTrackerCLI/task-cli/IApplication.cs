namespace task_cli
{
    public interface IApplication
    {
        Task HandleBusiness(string[] arguments);
    }
}
