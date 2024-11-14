
using HW12.Entities;

namespace HW12.Repository;

public interface IRepository
{

    List<DoList> GetAll();
    DoList GetByTitle(string Title);
    DoList GetById(int Id);
    void Add(DoList Task);
    void Delete(DoList Task);
    void Update(int id ,DoList Task);

}
