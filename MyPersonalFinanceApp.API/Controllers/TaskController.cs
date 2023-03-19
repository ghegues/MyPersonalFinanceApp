using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPersonalFinanceApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyPersonalFinanceApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public TaskController(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskDTO taskDTO)
        {
            try
            {
                var userEmail = User.FindFirstValue(ClaimTypes.Email);
                var user = await _userService.GetByEmail(userEmail);

                if (user == null)
                {
                    return NotFound("User not found.");
                }

                taskDTO.UserId = user.Id;

                var createdTask = await _taskService.AddAsync(taskDTO);

                if (createdTask != null)
                {
                    return CreatedAtAction(nameof(Create), new { id = createdTask.Title }, createdTask);
                }
                else
                {
                    return BadRequest(createdTask);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "TaskOwnerPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var task = await _taskService.GetByIdAsync(id);

                if (task != null)
                {
                    return Ok(task);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
