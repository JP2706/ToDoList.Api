namespace ToDoList.Api.Core.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Models.Domains.Task> GetAll(int userId);
        Models.Domains.Task Get(int id, int userId);
        void Add(Models.Domains.Task task);
        void Update(Models.Domains.Task task, int userId);
        void Delete(int id, int userId);
    }
}
