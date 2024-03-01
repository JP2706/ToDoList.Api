using System;
using System.Collections.Generic;

namespace ToDoList.Api.Core.Models.Domains
{
    public partial class Category
    {
        public Category()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
