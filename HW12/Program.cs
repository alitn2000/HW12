using HW12.UserServices;

IUserService userSevice = new UserService();
bool exit = false;
while (!exit)
{
    Console.WriteLine("\n--- Product Management Menu ---");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. Show All tasks");
    Console.WriteLine("3. Search task");
    Console.WriteLine("4. Update task");
    Console.WriteLine("5. Delete task");
    Console.WriteLine("6. Exit");
    Console.Write("Please choose an option: ");

    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
        continue;
    }

    switch (choice)
    {
        case 1:
            userSevice.AddTask();
            Console.ReadKey();
            Console.Clear();
            break;

        case 2:
            userSevice.ShowAllTasks();
            Console.ReadKey();
            Console.Clear();
            break;

        case 3:
            userSevice.SearchByTitle();
            Console.ReadKey();
            Console.Clear();
            break;

        case 4:
            userSevice.UpdateTask();
            Console.ReadKey();
            Console.Clear();
            break;

        case 5:
            userSevice.DeleteTask();
            Console.ReadKey();
            Console.Clear();
            break;

        case 6:
            exit = true;
            Console.WriteLine("Exiting the program.");
            break;

        default:
            Console.WriteLine("Invalid choice!!!");
            break;
    }
}