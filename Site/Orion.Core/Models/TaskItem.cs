namespace Orion.Core.Models
{
    /// <summary>
    /// Задача
    /// </summary>
    public class TaskItem : BaseEntity
    {
        /// <summary>
        /// Название задачи
        /// </summary>
        public string Title { get; set; } = null!;
        
        /// <summary>
        /// Описание задачи
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Статус задачи
        /// </summary>
        public Enums.TaskStatus Status { get; set; }
        
        /// <summary>
        /// Приоритет задачи
        /// </summary>
        public Enums.Priority Priority { get; set; }
        
        /// <summary>
        /// Идентификатор пользователя-создателя
        /// </summary>
        public string? CreatedById { get; set; }
        
        /// <summary>
        /// Пользователь-создатель
        /// </summary>
        public ApplicationUser? CreatedBy { get; set; }
        
        /// <summary>
        /// Идентификатор пользователя-исполнителя
        /// </summary>
        public string? AssignedToId { get; set; }
        
        /// <summary>
        /// Пользователь-исполнитель
        /// </summary>
        public ApplicationUser? AssignedTo { get; set; }
        
        /// <summary>
        /// Идентификатор группы, если задача групповая
        /// </summary>
        public int? GroupId { get; set; }
        
        /// <summary>
        /// Группа, если задача групповая
        /// </summary>
        public Group? Group { get; set; }
        
        /// <summary>
        /// Плановая дата выполнения
        /// </summary>
        public DateTime? DueDate { get; set; }
        
        /// <summary>
        /// Фактическая дата выполнения
        /// </summary>
        public DateTime? CompletedAt { get; set; }
        
        /// <summary>
        /// Метки задачи
        /// </summary>
        public ICollection<TaskTag> TaskTags { get; set; } = new List<TaskTag>();
        
        /// <summary>
        /// Подзадачи
        /// </summary>
        public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();
    }
} 