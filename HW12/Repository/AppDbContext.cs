using HW12.ConnectionStrings;
using HW12.Entities;
using Microsoft.EntityFrameworkCore;
namespace HW12.Repository;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Connection.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<DoList> DoLists { get; set; }

}
