
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
    public User GetUserByName(string userName)
    {
        var user = context.Users.FirstOrDefault(x => x.UserName ==userName);
        return user;
    }
    public List<User> GetAllUsers()
    {
        return context.Users.ToList();
    }


}
