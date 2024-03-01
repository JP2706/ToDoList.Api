using ToDoList.Api.Core.Repositories;

namespace ToDoList.Api.Core
{
    public interface IUnitOfWork
    {
        ITaskRepository TaskRepository { get; }
        IAccountRepository AccountRepository { get; }
        void Complete();
    }
}
