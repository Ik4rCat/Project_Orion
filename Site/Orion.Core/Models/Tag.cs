namespace Orion.Core.Models
{
    /// <summary>
    /// Тег для задач
    /// </summary>
    public class Tag : BaseEntity
    {
        /// <summary>
        /// Название тега
        /// </summary>
        public string Name { get; set; } = null!;
        
        /// <summary>
        /// Цвет тега (в формате HEX)
        /// </summary>
        public string Color { get; set; } = "#000000";
        
        /// <summary>
        /// Идентификатор пользователя-создателя
        /// </summary>
        public string? CreatedById { get; set; }
        
        /// <summary>
        /// Пользователь-создатель
        /// </summary>
        public ApplicationUser? CreatedBy { get; set; }
        
        /// <summary>
        /// Идентификатор группы, если тег общий для группы
        /// </summary>
        public int? GroupId { get; set; }
        
        /// <summary>
        /// Группа, если тег общий для группы
        /// </summary>
        public Group? Group { get; set; }
        
        /// <summary>
        /// Связи с задачами
        /// </summary>
        public ICollection<TaskTag> TaskTags { get; set; } = new List<TaskTag>();
    }
} 