using Orion.Core.Enums;


namespace Orion.Core.Models
{
    // <summary>
    // Связь между пользователем и группой
    // </summary>
    public class UserGroup : BaseEntity
    {
        // <summary>
        // Идентификатор пользователя
        // </summary>
        public string UserId { get; set; } = null!;
        
        // <summary>
        // Идентификатор группы
        // </summary>
        public int GroupId { get; set; }
        
        // <summary>
        // Роль пользователя в группе
        /// </summary>
        public GroupRole Role { get; set; }
        
        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        public virtual ApplicationUser User { get; set; } = null!;
        
        /// <summary>
        /// Ссылка на группу
        /// </summary>
        public virtual Group Group { get; set; } = null!;
    }
} 