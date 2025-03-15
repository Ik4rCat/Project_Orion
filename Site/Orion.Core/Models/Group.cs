namespace Orion.Core.Models
{
    /// <summary>
    /// Группа или семья для совместной работы
    /// </summary>
    public class Group : BaseEntity
    {
        /// <summary>
        /// Название группы
        /// </summary>
        public string Name { get; set; } = null!;
        
        /// <summary>
        /// Описание группы
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Аватар группы (URL изображения)
        /// </summary>
        public string? AvatarUrl { get; set; }
        
        /// <summary>
        /// Пользователи, входящие в группу
        /// </summary>
        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        
        /// <summary>
        /// Задачи группы
        /// </summary>
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        
        /// <summary>
        /// Заметки группы
        /// </summary>
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
} 