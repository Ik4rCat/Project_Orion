namespace Orion.Core.Models
{
    /// <summary>
    /// Метка для задачи
    /// </summary>
    public class TaskTag : BaseEntity
    {
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public int TaskId { get; set; }
        
        /// <summary>
        /// Задача
        /// </summary>
        public TaskItem Task { get; set; } = null!;
        
        /// <summary>
        /// Идентификатор тега
        /// </summary>
        public int TagId { get; set; }
        
        /// <summary>
        /// Тег
        /// </summary>
        public Tag Tag { get; set; } = null!;
    }
} 