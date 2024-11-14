namespace HW12.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
    public int NationalCode { get; set; }
    public List<DoList> DoLists { get; set; }
}
