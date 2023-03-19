using System.Collections.Generic;
using MyPersonalFinanceApp.Application.DTOs;
using MyPersonalFinanceApp.Domain.Entities;

namespace MyPersonalFinanceApp.Application.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDTO> GetByIdAsync(int id);
        Task<IEnumerable<TaskDTO>> GetAllAsync();
        Task<TaskDTO> AddAsync(TaskDTO taskDto);
        Task<bool> GetIfTaskBelongsUser(int userId, int taskId);
        Task UpdateAsync(int id, TaskDTO taskDto);
        Task DeleteAsync(int id);
    }
}
