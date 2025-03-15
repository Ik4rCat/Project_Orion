namespace Orion.Core.Models
{
    /// <summary>
    /// Базовый класс для всех сущностей
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Уникальный идентификатор сущности
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Дата создания сущности
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Дата последнего обновления сущности
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
} 