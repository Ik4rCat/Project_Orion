namespace Orion.Core.Models
{
    /// <summary>
    /// Подзадача
    /// </summary>
    public class SubTask : BaseEntity
    {
        /// <summary>
        /// Название подзадачи
        /// </summary>
        public string Title { get; set; } = null!;
        
        /// <summary>
        /// Описание подзадачи
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Выполнена ли подзадача
        /// </summary>
        public bool IsCompleted { get; set; }
        
        /// <summary>
        /// Дата выполнения подзадачи
        /// </summary>
        public DateTime? CompletedAt { get; set; }
        
        /// <summary>
        /// Идентификатор родительской задачи
        /// </summary>
        public int TaskId { get; set; }
        
        /// <summary>
        /// Родительская задача
        /// </summary>
        public TaskItem Task { get; set; } = null!;
        
        /// <summary>
        /// Порядок отображения подзадачи
        /// </summary>
        public int Order { get; set; }
    }
} 