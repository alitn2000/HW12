
using HW12.Entities;

namespace HW12.Repository;

public interface ITaskRepository
{

    List<DoList> GetAll(int Id);
    DoList GetByTitle(string Title, int Id);
    DoList GetById(int Id, int UserId);
    void Add(DoList Task);
    void Delete(DoList Task);
    void Update(int id ,DoList Task);

}
