using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoList.Api.Core;
using ToDoList.Api.Core.Models;
using ToDoList.Api.Core.Models.Domains;
using ToDoList.Api.Core.Repositories;
using ToDoList.Api.Core.Services;

namespace ToDoList.Api.Persistance.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(IUnitOfWork unitOfWork, AuthenticationSettings authenticationSettings)
        {
            _unitOfWork = unitOfWork;
            _authenticationSettings = authenticationSettings;
        }
        public void Register(AppUser user)
        {
            _unitOfWork.AccountRepository.Register(user);
            _unitOfWork.Complete();
        }

        public string LoginWithToken(UserLogin userLogin)
        {
            var user = _unitOfWork.AccountRepository.LoginUserNameGet(userLogin);

            if (user == null)
                throw new BadHttpRequestException("User Account Invalid.");

            if (userLogin.Password != user.Password)
                throw new BadHttpRequestException("User Password Incorrect");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer, 
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }
    }
}
