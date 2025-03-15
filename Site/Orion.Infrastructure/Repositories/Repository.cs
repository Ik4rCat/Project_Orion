using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Orion.Core.Interfaces;
using Orion.Core.Models;
using Orion.Infrastructure.Data;

namespace Orion.Infrastructure.Repositories
{
    /// <summary>
    /// Базовая реализация репозитория
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Получить все сущности
        /// </summary>
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Получить сущности по условию
        /// </summary>
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Получить сущность по идентификатору
        /// </summary>
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        public virtual async Task AddAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            await _dbSet.AddAsync(entity);
        }

        /// <summary>
        /// Обновить сущность
        /// </summary>
        public virtual async Task UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        public virtual async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Удалить сущность по идентификатору
        /// </summary>
        public virtual async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                await DeleteAsync(entity);
            }
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


/// <summary>
/// Получить сущность по идентификатору
/// </summary>
        public virtual async Task<T?> GetByIdAsync(string id)
        {
    // Преобразуйте строковый идентификатор в тип, который используется в вашей базе данных
    // Например, если id - это Guid:
        if (Guid.TryParse(id, out var guidId))
            {
            return await _dbSet.FindAsync(guidId);
            }
        return null; // или выбросьте исключение, если id недействителен
        }
    }
} 