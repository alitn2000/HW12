using Azure.Core;
using HW12.Entities;
using HW12.Repository;

namespace HW12.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository userRepo = new UserRepository();
    public static User CurrentUser { get; set; }
    public bool Login()
    {
        Console.Write("Enter UserName:");
        string userName = Console.ReadLine();
        Console.Write("Enter Password:");
        string Pass = Console.ReadLine();
        var user = userRepo.GetUserByName(userName);
        if (user is null)
        {
            Console.WriteLine("User not found");
            return false;
        }
        if (user.Password != Pass)
        {
            Console.WriteLine("Password is incorrect!!!");
            return false;
        }
        CurrentUser = user;
        Console.WriteLine("LogIn successfull.");
        return true;
    }

    public void Register()
    {
        Console.Write("Enter your UserName: ");
        string userName = Console.ReadLine();
        var ExistUser = userRepo.GetUserByName(userName);
        if (ExistUser is not null)
        {
            Console.WriteLine("User with this username is already exist!!!");
            return;
        }
        Console.Write("Enter your Password: ");
        string Pass = Console.ReadLine();
        Console.Write("Enter your Age: ");
        int Age = int.Parse(Console.ReadLine());
        Console.Write("Enter your NationalCode: ");
        int NCode = int.Parse(Console.ReadLine());
        User user = new User()
        {
            UserName =userName,
            Password = Pass,
            Age = Age,
            NationalCode = NCode   
        };
        userRepo.AddUser(user);
        Console.WriteLine("Register Successfull");
    }
}
