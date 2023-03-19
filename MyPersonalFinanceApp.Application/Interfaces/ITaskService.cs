using System.Collections.Generic;
using MyPersonalFinanceApp.Application.DTOs;
using MyPersonalFinanceApp.Domain.Entities;

namespace MyPersonalFinanceApp.Application.Interfaces
{
    public interface ITaskService
    {
        TaskDTO GetById(int id);
        IEnumerable<TaskDTO> GetAll();
        int Create(TaskDTO taskDTO);
        void Update(TaskDTO taskDTO);
        void Delete(int id);
    }
}
