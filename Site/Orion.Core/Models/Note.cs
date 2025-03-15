namespace Orion.Core.Models
{
    /// <summary>
    /// Заметка
    /// </summary>
    public class Note : BaseEntity
    {
        /// <summary>
        /// Заголовок заметки
        /// </summary>
        public string Title { get; set; } = null!;
        
        /// <summary>
        /// Содержимое заметки
        /// </summary>
        public string Content { get; set; } = null!;
        
        /// <summary>
        /// Тип заметки
        /// </summary>
        public Enums.NoteType Type { get; set; }
        
        /// <summary>
        /// Идентификатор пользователя-создателя
        /// </summary>
        public string? CreatedById { get; set; }
        
        /// <summary>
        /// Пользователь-создатель
        /// </summary>
        public ApplicationUser? CreatedBy { get; set; }
        
        /// <summary>
        /// Идентификатор группы, если заметка общая для группы
        /// </summary>
        public int? GroupId { get; set; }
        
        /// <summary>
        /// Группа, если заметка общая для группы
        /// </summary>
        public Group? Group { get; set; }
        
        /// <summary>
        /// Избранная заметка
        /// </summary>
        public bool IsFavorite { get; set; }
        
        /// <summary>
        /// Порядок отображения заметки
        /// </summary>
        public int Order { get; set; }
        
        /// <summary>
        /// Метки заметки
        /// </summary>
        public ICollection<NoteTag> NoteTags { get; set; } = new List<NoteTag>();
    }
} 