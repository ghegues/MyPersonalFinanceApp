using Microsoft.EntityFrameworkCore;
using MyPersonalFinanceApp.Domain.Entities;
using MyPersonalFinanceApp.Infra.Data;
using MyPersonalFinanceApp.Infra.Interfaces;

namespace MyPersonalFinanceApp.Infra.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly Context _context;

        public TaskRepository(Context context)
        {
            _context = context;
        }

        public async Task<Tarefa> ObterPorId(int id)
        {
            return await _context.Tasks
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tarefa>> ObterPorUsuario(int idUsuario)
        {
            return await _context.Tasks
                .Include(t => t.User)
                .Where(t => t.UserId == idUsuario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterPorStatus(int idUsuario, StatusTarefa status)
        {
            return await _context.Tasks
                .Include(t => t.User)
                .Where(t => t.IdUsuario == idUsuario && t.Status == status)
                .ToListAsync();
        }

        public async Task Adicionar(Tarefa tarefa)
        {
            await _context.Tasks.AddAsync(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Tarefa tarefa)
        {
            _context.Tasks.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var tarefa = await ObterPorId(id);
            _context.Tasks.Remove(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}
