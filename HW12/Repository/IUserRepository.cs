using HW12.Entities;

namespace HW12.Repository;

public interface IUserRepository
{
    void AddUser(User user);
    User GetUserByName(string userName);
    List<User> GetAllUsers();
}
