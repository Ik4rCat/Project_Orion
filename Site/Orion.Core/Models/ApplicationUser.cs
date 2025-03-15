using Microsoft.AspNetCore.Identity;

namespace Orion.Core.Models
{
    /// <summary>
    /// Модель пользователя приложения
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Имя пользователя для отображения
        /// </summary>
        public string DisplayName { get; set; } = null!;
        
        /// <summary>
        /// Аватар пользователя (URL изображения)
        /// </summary>
        public string? AvatarUrl { get; set; }
        
        /// <summary>
        /// Тема оформления пользователя
        /// </summary>
        public Enums.Theme Theme { get; set; }
        
        /// <summary>
        /// Краткая информация о пользователе
        /// </summary>
        public string? Bio { get; set; }
        
        /// <summary>
        /// Дата последнего входа в систему
        /// </summary>
        public DateTime? LastLogin { get; set; }
        
        /// <summary>
        /// Группы/семьи, в которых состоит пользователь
        /// </summary>
        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        
        /// <summary>
        /// Задачи пользователя
        /// </summary>
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        
        /// <summary>
        /// Заметки пользователя
        /// </summary>
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
} 