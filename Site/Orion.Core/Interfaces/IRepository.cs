using System.Linq.Expressions;
using Orion.Core.Models;

namespace Orion.Core.Interfaces
{
    /// <summary>
    /// Базовый интерфейс репозитория
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получить все сущности
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();
        
        /// <summary>
        /// Получить сущности по условию
        /// </summary>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        
        /// <summary>
        /// Получить сущность по идентификатору
        /// </summary>
        Task<T?> GetByIdAsync(string id);
        
        /// <summary>
        /// Добавить сущность
        /// </summary>
        Task AddAsync(T entity);
        
        /// <summary>
        /// Обновить сущность
        /// </summary>
        Task UpdateAsync(T entity);
        
        /// <summary>
        /// Удалить сущность
        /// </summary>
        Task DeleteAsync(T entity);
        
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        Task SaveChangesAsync();
    }

    public interface INoteRepository : IRepository<Note> { }
    public interface IGroupRepository : IRepository<Group> { }
    public interface IUserRepository : IRepository<ApplicationUser> { }
    public interface IUserGroupRepository : IRepository<UserGroup> { }
} 