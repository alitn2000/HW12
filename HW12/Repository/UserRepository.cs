
using HW12.Entities;

namespace HW12.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext context = new AppDbContext();

    public void AddUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }
    public User GetUser(string userName, string Pass)
    {
        var user = context.Users.FirstOrDefault(x => x.UserName ==userName && x.Password == Pass);
        return user;
    }
    public List<User> GetAllUsers()
    {
        return context.Users.ToList();
    }

    public bool CheckUserExist(string userName)
    {
        var Flag = context.Users.Any(x => x.UserName == userName);
        return Flag;
    }
}
