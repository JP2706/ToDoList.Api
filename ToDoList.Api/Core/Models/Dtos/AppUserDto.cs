﻿namespace ToDoList.Api.Core.Models.Dtos
{
    public class AppUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
