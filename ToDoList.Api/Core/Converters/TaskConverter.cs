using System.Runtime.InteropServices;
using ToDoList.Api.Core.Models.Dtos;

namespace ToDoList.Api.Core.Converters
{
    public static class TaskConverter
    {
        public static TaskDto ToDto(this Models.Domains.Task task)
        {
            return new TaskDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                UserId = task.UserId,
                IsExecuted = task.IsExecuted,
                CategoryId = task.CategoryId,
            };
        }

        public static Models.Domains.Task ToDao(this TaskDto taskDto)
        {
            return new Models.Domains.Task
            {
                Id = taskDto.Id,
                Name = taskDto.Name,
                Description = taskDto.Description,
                UserId = taskDto.UserId,
                IsExecuted = taskDto.IsExecuted,
                CategoryId = taskDto.CategoryId,
            };
        }

        public static IEnumerable<TaskDto> ToDtos(this IEnumerable<Models.Domains.Task> model)
        {
            if (model == null)
                return Enumerable.Empty<TaskDto>();

            return model.Select(x => x.ToDto());
        }

        public static IEnumerable<Models.Domains.Task> ToDaos(this IEnumerable<TaskDto> model) 
        {
            if(model == null)
                return Enumerable.Empty<Models.Domains.Task>();

            return model.Select(x => x.ToDao());
        }

    }
}
