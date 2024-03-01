using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Core.Converters;
using ToDoList.Api.Core.Models.Dtos;
using ToDoList.Api.Core.Response;
using ToDoList.Api.Core.Services;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public Response RegisterUser(AppUserDto userDto)
        {
            var response = new Response();

            try
            {
                _accountService.Register(userDto.ToDeo());
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error(ex.Source, ex.Message));
                throw;
            }

            return response;
        }

        [HttpPost("Login")]
        public DataResponse<string> LoginUser(UserLoginDto userLogin)
        {
            var response = new DataResponse<string>();

            try
            {
                response.Data = _accountService.LoginWithToken(userLogin.ToDao());
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error(ex.Source, ex.Message));
                throw;
            }

            return response;
        }
    }
}
