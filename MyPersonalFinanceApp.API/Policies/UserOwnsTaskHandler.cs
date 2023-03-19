using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyPersonalFinanceApp.Application.Interfaces;

namespace MyPersonalFinanceApp.API.Authorization
{
    public class UserOwnsTaskHandler : AuthorizationHandler<UserOwnsTaskRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;
        private readonly ILogger<UserOwnsTaskHandler> _logger;

        public UserOwnsTaskHandler(IHttpContextAccessor httpContextAccessor, ITaskService taskService, ILogger<UserOwnsTaskHandler> logger, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _taskService = taskService;
            _logger = logger;
            _userService = userService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserOwnsTaskRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var email = httpContext.User.FindFirstValue(ClaimTypes.Email);

            var taskIdStr = _httpContextAccessor.HttpContext.Request.RouteValues["id"]?.ToString();
            if (int.TryParse(taskIdStr, out int taskId))
            {
                var task = await _taskService.GetByIdAsync(taskId);
                if (task == null)
                {
                    context.Fail();
                    return;
                }

                var user = await _userService.GetByEmail(email);
                if (user == null)
                {
                    context.Fail();
                    return;
                }

                if (task.UserId == user.Id)
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
        }
    }
}