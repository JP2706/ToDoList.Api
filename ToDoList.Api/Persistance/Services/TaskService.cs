using ToDoList.Api.Core;
using ToDoList.Api.Core.Services;

namespace ToDoList.Api.Persistance.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Core.Models.Domains.Task> GetAll(int userId)
        {
            return _unitOfWork.TaskRepository.GetAll(userId);
        }

        public Core.Models.Domains.Task Get(int id, int userId)
        {
            return _unitOfWork.TaskRepository.Get(id, userId);
        }

        public void Add(Core.Models.Domains.Task task) 
        {
            _unitOfWork.TaskRepository.Add(task);
            _unitOfWork.Complete();
        }

        public void Update(Core.Models.Domains.Task task, int userId)
        {
            _unitOfWork.TaskRepository.Update(task, userId);
            _unitOfWork.Complete();
        }

        public void Delete(int id, int userId)
        {
            _unitOfWork.TaskRepository.Delete(id, userId);
            _unitOfWork.Complete();
        }
    }
}
