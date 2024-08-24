namespace task_cli
{
    public class Application : IApplication
    {
        public string[] Paramters { get; set; }
        public Application(string[] parameters)
        {
            Paramters = parameters;
        }

        public void HandleBusiness()
        {
            Console.WriteLine("Hell World!");

            // Parse command from console paramters
            if (Paramters == null || Paramters.Length == 0)
            {
                Console.WriteLine("Program needs command (add, update, delete, mark-in-progress, mark-done, list");
            }
            else
            {

            }
        }
    }
}
