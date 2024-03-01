using ToDoList.Api.Core;
using ToDoList.Api.Core.Repositories;
using ToDoList.Api.Persistance.Repositories;

namespace ToDoList.Api.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IToDoListContext _context;
        public UnitOfWork(IToDoListContext context)
        {
            _context = context;
            TaskRepository = new TaskRepository(context);
            AccountRepository = new AccountRepository(context);
        }

        public ITaskRepository TaskRepository { get; }
        public IAccountRepository AccountRepository { get; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
