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

        public async Task<Tarefa> GetById(int id)
        {
            return await _context.Tasks
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> GetIfTaskBelongsUser(int userId, int taskId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);
            return task != null;
        }

        public async Task<IEnumerable<Tarefa>> GetAll()
        {
            return await _context.Tasks
                .Include(t => t.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> GetByUser(int idUsuario)
        {
            return await _context.Tasks
                .Include(t => t.User)
                .Where(t => t.UserId == idUsuario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> GetByStatus(int idUsuario, StatusTarefa status)
        {
            return await _context.Tasks
                .Include(t => t.User)
                .Where(t => t.UserId == idUsuario && t.Status == status)
                .ToListAsync();
        }

        public async Task<int> Add(Tarefa tarefa)
        {
            await _context.Tasks.AddAsync(tarefa);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Tarefa tarefa)
        {
            _context.Tasks.Update(tarefa);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var tarefa = await GetById(id);
            _context.Tasks.Remove(tarefa);
            return await _context.SaveChangesAsync();
        }
    }
}
