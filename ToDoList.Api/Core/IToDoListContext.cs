using Microsoft.EntityFrameworkCore;
using ToDoList.Api.Core.Models.Domains;

namespace ToDoList.Api.Core
{
    public interface IToDoListContext
    {
        DbSet<AppUser> AppUsers { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Models.Domains.Task> Tasks { get; set; }
        int SaveChanges();
    }
}
