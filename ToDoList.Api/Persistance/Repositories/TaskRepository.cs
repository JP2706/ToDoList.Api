using ToDoList.Api.Core;
using ToDoList.Api.Core.Repositories;

namespace ToDoList.Api.Persistance.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IToDoListContext _context;

        public TaskRepository(IToDoListContext context)
        {
            _context = context;
        }
        public IEnumerable<Core.Models.Domains.Task> GetAll(int userId)
        {
            return _context.Tasks.Where(x => x.UserId == userId);
        }

        public Core.Models.Domains.Task Get(int id, int userId) 
        {
            return _context.Tasks.Where(x => x.UserId == userId).Single(x => x.Id == id);
        }

        public void Add(Core.Models.Domains.Task task) 
        {
            _context.Tasks.Add(task);
        }

        public void Update(Core.Models.Domains.Task task, int userId)
        {
            var taskToUpdate = _context.Tasks.Where(x => x.UserId == userId).Single(x => x.Id == task.Id);
            taskToUpdate.Name = task.Name;
            taskToUpdate.Description = task.Description;
            taskToUpdate.CategoryId = task.CategoryId;
            taskToUpdate.IsExecuted = task.IsExecuted;
        }

        public void Delete(int id, int userId)
        {
            var taskToDelete = _context.Tasks.Where(x => x.UserId == userId).Single(x => x.Id == id);
            _context.Tasks.Remove(taskToDelete);
        }
    }
}
