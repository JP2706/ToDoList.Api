using System;
using System.Collections.Generic;

namespace ToDoList.Api.Core.Models.Domains
{
    public partial class AppUser
    {
        public AppUser()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
