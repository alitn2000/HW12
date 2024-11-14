using HW12.Enums;
using System.Threading.Channels;

namespace HW12.Entities;

public class DoList
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public StatusEnum Status { get; set; }
    public PriorityEnum Priority { get; set; }
    public DateTime EndTime { get; set; }

    public override string ToString()
    {
        return $"{Id}.{Title} <{Priority}> -- > Status : {Status} || Duration: ({EndTime:yyyy-MM-dd} \n {Description}) \n ------------------------------------------------ ";
    }
}
