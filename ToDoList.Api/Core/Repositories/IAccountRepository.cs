using ToDoList.Api.Core.Models;
using ToDoList.Api.Core.Models.Domains;

namespace ToDoList.Api.Core.Repositories
{
    public interface IAccountRepository
    {
        void Register(AppUser user);
        AppUser LoginUserNameGet(UserLogin userLogin);
    }
}
