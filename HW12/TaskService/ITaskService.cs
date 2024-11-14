namespace HW12.UserServices;

public interface ITaskService
{
    void AddTask();
    void DeleteTask();
    void UpdateTask();
    void ShowAllTasks();
    void SearchByTitle();
}
