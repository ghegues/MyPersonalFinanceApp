using MyPersonalFinanceApp.Application.Interfaces;
using MyPersonalFinanceApp.Domain.Entities;
using MyPersonalFinanceApp.Infra.Interfaces;

namespace MyPersonalFinanceApp.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // Implemente os métodos para interagir com a entidade Task
    }
}
