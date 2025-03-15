namespace Orion.Core.Models
{
    /// <summary>
    /// Метка для заметки
    /// </summary>
    public class NoteTag : BaseEntity
    {
        /// <summary>
        /// Идентификатор заметки
        /// </summary>
        public int NoteId { get; set; }
        
        /// <summary>
        /// Заметка
        /// </summary>
        public Note Note { get; set; } = null!;
        
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