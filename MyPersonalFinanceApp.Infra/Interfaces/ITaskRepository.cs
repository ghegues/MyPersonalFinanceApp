using MyPersonalFinanceApp.Domain.Entities;

namespace MyPersonalFinanceApp.Infra.Interfaces
{
    public interface ITaskRepository
    {
        Task<Tarefa> GetById(int id);
        Task<IEnumerable<Tarefa>> GetAll();
        Task<IEnumerable<Tarefa>> GetByUser(int idUsuario);
        Task<IEnumerable<Tarefa>> GetByStatus(int idUsuario, StatusTarefa status);
        Task<bool> GetIfTaskBelongsUser(int userId, int taskId);
        Task<int> Add(Tarefa tarefa);
        Task<int> Update(Tarefa tarefa);
        Task<int> Delete(int id);
    }
}
