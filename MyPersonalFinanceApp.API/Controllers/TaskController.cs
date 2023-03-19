using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPersonalFinanceApp.Application.Interfaces;
using MyPersonalFinanceApp.Domain.Entities;

namespace MyPersonalFinanceApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // Implemente os métodos para interagir com a entidade Task
    }
}
