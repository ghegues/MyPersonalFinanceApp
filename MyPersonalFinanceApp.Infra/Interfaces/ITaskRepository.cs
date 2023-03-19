using MyPersonalFinanceApp.Domain.Entities;

namespace MyPersonalFinanceApp.Infra.Interfaces
{
    public interface ITaskRepository
    {
        Task<Tarefa> ObterPorId(int id);
        Task<IEnumerable<Tarefa>> ObterPorUsuario(int idUsuario);
        Task<IEnumerable<Tarefa>> ObterPorStatus(int idUsuario, StatusTarefa status);
        Task Adicionar(Tarefa tarefa);
        Task Atualizar(Tarefa tarefa);
        Task Remover(int id);
    }
}
