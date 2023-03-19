using System.Collections.Generic;
using AutoMapper;
using MyPersonalFinanceApp.Application.DTOs;
using MyPersonalFinanceApp.Application.Interfaces;
using MyPersonalFinanceApp.Domain.Entities;
using MyPersonalFinanceApp.Infra.Interfaces;

namespace MyPersonalFinanceApp.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDTO>> GetAllAsync()
        {
            var tasks = await _taskRepository.GetAll();
            return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
        }

        public async Task<TaskDTO> GetByIdAsync(int id)
        {
            var task = await _taskRepository.GetById(id);
            return _mapper.Map<TaskDTO>(task);
        }

        public async Task<TaskDTO> AddAsync(TaskDTO taskDto)
        {
            var task = _mapper.Map<Tarefa>(taskDto);
            await _taskRepository.Add(task);
            return taskDto;
        }

        public Task<bool> GetIfTaskBelongsUser(int userId, int taskId)
        {
            return _taskRepository.GetIfTaskBelongsUser(userId, taskId);
        }

        public async Task UpdateAsync(int id, TaskDTO taskDto)
        {
            var taskToUpdate = await _taskRepository.GetById(id);

            if (taskToUpdate == null)
            {
                throw new ArgumentException("Task not found.");
            }

            _mapper.Map(taskDto, taskToUpdate);

            await _taskRepository.Update(taskToUpdate);
        }

        public async Task DeleteAsync(int id)
        {
            await _taskRepository.Delete(id);
        }
    }
}
