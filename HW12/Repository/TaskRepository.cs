using HW12.Entities;

namespace HW12.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext context = new AppDbContext();
    public void Add(DoList Task)
    {
        context.DoLists.Add(Task);
        context.SaveChanges();
    }

    public void Delete(DoList Task)
    {
        context.DoLists.Remove(Task);
        context.SaveChanges();
    }

    public List<DoList> GetAll(int Id)
    {
        var Tasks = context.DoLists.Where(t => t.UserId ==Id)
            .OrderBy(t => t.EndTime)
            .ToList();
        return Tasks;
    }

    public DoList GetById(int Id, int UserId)
    {
       var Task = context.DoLists.FirstOrDefault(t => t.Id == Id && t.UserId == UserId);
        return Task;
    }

    public DoList GetByTitle(string Title, int Id)
    {
        var Task = context.DoLists.FirstOrDefault(t => t.Title == Title && t.UserId == Id);
        return Task;
    }

    public void Update(int Id,DoList Task)
    {
       var CurrentTask = GetById(Id, UserService.UserService.CurrentUser.Id);
        CurrentTask.Title = Task.Title;
        CurrentTask.Description = Task.Description;
        CurrentTask.EndTime = Task.EndTime;
        CurrentTask.Priority = Task.Priority;
        CurrentTask.Status = Task.Status;
        context.SaveChanges();
    }

}
