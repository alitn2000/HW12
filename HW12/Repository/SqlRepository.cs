using HW12.Entities;

namespace HW12.Repository;

public class SqlRepository : IRepository
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

    public List<DoList> GetAll()
    {
        var Tasks = context.DoLists.ToList();
        return Tasks;
    }

    public DoList GetById(int Id)
    {
       var Task = context.DoLists.FirstOrDefault(t => t.Id == Id);
        return Task;
    }

    public DoList GetByTitle(string Title)
    {
        var Task = context.DoLists.FirstOrDefault(t => t.Title == Title);
        return Task;
    }

    public void Update(int Id,DoList Task)
    {
       var CurrentTask = GetById(Id);
        CurrentTask.Title = Task.Title;
        CurrentTask.Description = Task.Description;
        CurrentTask.EndTime = Task.EndTime;
        CurrentTask.Priority = Task.Priority;
        CurrentTask.Status = Task.Status;
        context.SaveChanges();
    }

}
