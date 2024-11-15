using HW12.Entities;
using HW12.Enums;
using HW12.Repository;
using HW12.UserService;

namespace HW12.UserServices;

public class TaskService : ITaskService
{
    private readonly ITaskRepository Sql = new TaskRepository();
    public void AddTask()
    {
        Console.Write("Enter your Task Title: ");
        string title = Console.ReadLine();
        var existTask = Sql.GetByTitle(title, UserService.UserService.CurrentUser.Id);

        if (existTask != null)
        {
            Console.WriteLine("You already have a task with this title in your list!!!");
            return;
        }

        Console.Write("Enter a description for your task: ");
        string? description = Console.ReadLine();

        Console.WriteLine("Enter Priority (1.High, 2.Medium, 3.Low): ");
        if (!int.TryParse(Console.ReadLine(), out int priority) || priority < 1 || priority > 3)
        {
            Console.WriteLine("Invalid input for priority!!!");
            return;
        }

        Console.Write("Enter the deadline (yyyy-mm-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Invalid date format!!!");
            return;
        }


        PriorityEnum priorityEnum = (PriorityEnum)priority;
        StatusEnum statusEnum = StatusEnum.Doing;

        DoList task = new DoList
        {
            Title = title,
            Description = description,
            EndTime = date,
            Priority = priorityEnum,
            Status = statusEnum,
            UserId = UserService.UserService.CurrentUser.Id
        };

        Sql.Add(task);
        Console.WriteLine("Task added.");
    }

    public void DeleteTask()
    {
        ShowAllTasks();
        Console.Write("Enter task id :");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var ExistTask = Sql.GetById(id, UserService.UserService.CurrentUser.Id);
            if (ExistTask is not null)
            {
                Sql.Delete(ExistTask);
                Console.WriteLine("Task Removed");

            }
            else
            {
                Console.WriteLine("invalid Id!!!");
                return;
            }
        }
        else
        {
            Console.WriteLine("Invalid input!!!");
            return;
        }
    }

    public void SearchByTitle()
    {
        Console.WriteLine("Enter Title");
        string T = Console.ReadLine();
        var SearchedTasks = Sql.Search(T);
        if (SearchedTasks != null && SearchedTasks.Any())
        {
            foreach (var Task in SearchedTasks)
            {
                Console.WriteLine(Task.ToString());
            }
        }
        else
        {
            Console.WriteLine("No such task find with your string!!!");
            return;
        }
    }

    public void ShowAllTasks()
    {
        var Tasks = Sql.GetAll(UserService.UserService.CurrentUser.Id);
        if (Tasks is null)
        {
            Console.WriteLine("No task submitted");
            return;
        }
        foreach (var Task in Tasks)
        {
            Console.WriteLine(Task.ToString());
        }
    }

    public void UpdateTask()
    {

        Console.Write("Enter the Id of Task : ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid input!!!");
            return;
        }

        var ExistTask = Sql.GetById(id, UserService.UserService.CurrentUser.Id);
        if (ExistTask == null)
        {
            Console.WriteLine("dont found task with this id!!!");
        }

        bool continuee = true;
        while (continuee)
        {
            Console.WriteLine("Current Task Details:");
            Console.WriteLine(ExistTask.ToString());

            Console.WriteLine("Which part do you want to update? 1.Title 2.Priority 3.Status 4.Description 5.EndTime 6.Finish Editing");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new Title: ");
                    ExistTask.Title = Console.ReadLine();
                    break;

                case 2:
                    Console.Write("Enter new Priority (1.High 2.Medium 3.Low): ");
                    if (!int.TryParse(Console.ReadLine(), out int P) || P < 1 || P > 3)
                    {
                        Console.WriteLine("Invalid input for Priority.");
                        continue;
                    }
                    else
                    {
                        ExistTask.Priority = (PriorityEnum)P;
                    }
                    break;

                case 3:
                    Console.Write("Enter new Status (1.Doing 2.Done 3.Canceled): ");
                    if (!int.TryParse(Console.ReadLine(), out int S) || S < 1 || S > 3)
                    {
                        Console.WriteLine("Invalid input for Status.");
                        continue;
                    }
                    else
                    {
                        ExistTask.Status = (StatusEnum)S;
                    }
                    break;

                case 4:
                    Console.WriteLine("Enter new Description:");
                    string? D = Console.ReadLine();
                    ExistTask.Description = D;
                    break;

                case 5:
                    Console.WriteLine("Enter new date(yyyy-mm-dd)");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    {
                        Console.WriteLine("Invalid date format!!!");
                        return;
                    }
                    ExistTask.EndTime = date;
                    break;

                case 6:
                    continuee = false;
                    Console.WriteLine("Edditing finished.");
                    break;

                default:
                    Console.WriteLine("Invalid choice!!!");
                    break;
            }

            if (continuee)
            {
                Sql.Update(id, ExistTask);
                Console.WriteLine("Product updated successfully.");
            }
        }

    }
}
