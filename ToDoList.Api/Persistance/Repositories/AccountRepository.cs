using ToDoList.Api.Core;
using ToDoList.Api.Core.Models;
using ToDoList.Api.Core.Models.Domains;
using ToDoList.Api.Core.Repositories;

namespace ToDoList.Api.Persistance.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IToDoListContext _context;
        public AccountRepository(IToDoListContext context)
        {
            _context = context;
        }

        public void Register(AppUser user) 
        {
            user.Id = 0;
            _context.AppUsers.Add(user);
        }

        public AppUser LoginUserNameGet(UserLogin userLogin)
        {
            return _context.AppUsers.FirstOrDefault(x => x.UserName == userLogin.UserName);
        }

    }
}
