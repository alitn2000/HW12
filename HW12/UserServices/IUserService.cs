namespace HW12.UserServices;

public interface IUserService
{
    void AddTask();
    void DeleteTask();
    void UpdateTask();
    void ShowAllTasks();
    void SearchByTitle();
}
