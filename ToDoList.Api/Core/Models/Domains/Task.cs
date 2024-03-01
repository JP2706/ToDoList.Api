using System;
using System.Collections.Generic;

namespace ToDoList.Api.Core.Models.Domains
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int UserId { get; set; }
        public bool IsExecuted { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
    }
}
