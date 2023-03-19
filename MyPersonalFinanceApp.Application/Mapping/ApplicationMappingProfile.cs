using AutoMapper;
using MyPersonalFinanceApp.Application.DTOs;
using MyPersonalFinanceApp.Domain.Entities;

namespace MyPersonalFinanceApp.Application.Utils
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Tarefa, TaskDTO>();
            CreateMap<TaskDTO, Tarefa>();
        }
    }
}