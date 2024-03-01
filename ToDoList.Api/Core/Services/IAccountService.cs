using ToDoList.Api.Core.Models;
using ToDoList.Api.Core.Models.Domains;

namespace ToDoList.Api.Core.Services
{
    public interface IAccountService
    {
        void Register(AppUser user);
        string LoginWithToken(UserLogin userLogin);
    }
}
