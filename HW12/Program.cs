using HW12.UserService;
using HW12.UserServices;

IUserService userService = new UserService();
ITaskService taskService = new TaskService();

bool exit = false;
bool trueexit = false;
while (trueexit is false)
{
    while (UserService.CurrentUser is null)
    {
        Console.WriteLine("<--- ToDoList --->");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.WriteLine("3. Exit");
        Console.Write("Please choose an option: ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            Console.ReadKey();
            Console.Clear();
            continue;
        }

        switch (choice)
        {
            case 1:
                if (userService.Login())
                    exit = true;
                Console.ReadKey();
                Console.Clear();
                break;

            case 2:
                userService.Register();
                Console.ReadKey();
                Console.Clear();
                break;

            case 3:
                trueexit = true;
                Console.WriteLine("Exiting the program.");
                Console.ReadKey();
                Console.Clear();
                break;

            default:
                Console.WriteLine("Invalid choice!!!");
                Console.ReadKey();
                Console.Clear();
                break;
        }

        if (trueexit)
            break;
    }

    while (exit is true && UserService.CurrentUser is not null)
    {
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. Show All tasks");
        Console.WriteLine("3. Search task");
        Console.WriteLine("4. Update task");
        Console.WriteLine("5. Delete task");
        Console.WriteLine("6. Logout");
        Console.Write("Please choose an option: ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
            continue;
        }

        switch (choice)
        {
            case 1:
                taskService.AddTask();
                Console.ReadKey();
                Console.Clear();
                break;

            case 2:
                taskService.ShowAllTasks();
                Console.ReadKey();
                Console.Clear();
                break;

            case 3:
                taskService.SearchByTitle();
                Console.ReadKey();
                Console.Clear();
                break;

            case 4:
                taskService.UpdateTask();
                Console.ReadKey();
                Console.Clear();
                break;

            case 5:
                taskService.DeleteTask();
                Console.ReadKey();
                Console.Clear();
                break;

            case 6:
                UserService.CurrentUser = null;
                Console.WriteLine("Logged out successfully.");
                Console.ReadKey();
                Console.Clear();
                break;

            default:
                Console.WriteLine("Invalid choice!!!");
                Console.ReadKey();
                Console.Clear();
                break;
        }
    }
}

