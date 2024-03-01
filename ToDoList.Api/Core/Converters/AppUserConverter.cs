using ToDoList.Api.Core.Models;
using ToDoList.Api.Core.Models.Domains;
using ToDoList.Api.Core.Models.Dtos;

namespace ToDoList.Api.Core.Converters
{
    public static class AppUserConverter
    {
        public static AppUserDto ToDto(this AppUser user)
        {
            return new AppUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
            };
        }

        public static AppUser ToDeo(this AppUserDto user)
        {
            return new AppUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
            };
        }

        public static UserLoginDto ToDto(this UserLogin user) 
        {
            return new UserLoginDto
            {
                UserName = user.UserName,
                Password = user.Password
            };
        }

        public static UserLogin ToDao(this UserLoginDto user) 
        {
            return new UserLogin
            {
                UserName = user.UserName,
                Password = user.Password
            };
        }

    }
}
