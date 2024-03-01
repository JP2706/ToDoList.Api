using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoList.Api.Core.Converters;
using ToDoList.Api.Core.Models.Dtos;
using ToDoList.Api.Core.Response;
using ToDoList.Api.Core.Services;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskServie;
        public TaskController(ITaskService taskServie)
        {
            _taskServie = taskServie;
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }

        [HttpGet]
        [Authorize]
        public DataResponse<IEnumerable<TaskDto>> GetAll()
        {
            var userId = GetUserId();
            var response = new DataResponse<IEnumerable<TaskDto>>();

            try
            {
                response.Data = _taskServie.GetAll(userId).ToDtos();
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error(ex.Source, ex.Message));
                throw;
            }

            return response;
        }

        [HttpGet("{id}")]
        [Authorize]
        public DataResponse<TaskDto> Get(int id)
        {
            var userId = GetUserId();
            var response = new DataResponse<TaskDto>();
            try
            {
                response.Data = _taskServie.Get(id, userId).ToDto();
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error(ex.Source, ex.Message));
                throw;
            }

            return response;
        }

        [HttpPost("Add")]
        [Authorize]
        public Response Add(TaskDto dto)
        {
            var response = new Response();
            dto.UserId = GetUserId();
            try
            {
                _taskServie.Add(dto.ToDao());
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error(ex.Source, ex.Message));
                throw;
            }

            return response;
        }

        [HttpPut("Update")]
        [Authorize]
        public Response Update(TaskDto task)
        {
            var response = new Response();
            var userId = GetUserId();
            task.UserId = userId;
            try
            {
                _taskServie.Update(task.ToDao(), userId);
            }
            catch (Exception ex)
            {
                response.Errors.Add(new Error(ex.Source, ex.Message));
                throw;
            }

            return response;
        }

        [HttpDelete("Delete/{id}")]
        [Authorize]
        public Response Delete(int id)
        {
            var response = new Response();
            var userId = GetUserId();
            try
            {
                _taskServie.Delete(id, userId);
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
