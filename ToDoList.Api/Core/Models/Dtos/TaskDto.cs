namespace ToDoList.Api.Core.Models.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int UserId { get; set; }
        public bool IsExecuted { get; set; }
        public int CategoryId { get; set; }
    }
}
