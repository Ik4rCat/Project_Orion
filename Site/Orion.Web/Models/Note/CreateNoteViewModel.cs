using System.ComponentModel.DataAnnotations;
using Orion.Core.Enums;

namespace Orion.Web.Models.Note
{
    public class CreateNoteViewModel
    {
        [Required(ErrorMessage = "Заголовок обязателен")]
        [StringLength(200, ErrorMessage = "Заголовок не может быть длиннее 200 символов")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Содержание обязательно")]
        [Display(Name = "Содержание")]
        public string Content { get; set; } = null!;

        [Display(Name = "Тип заметки")]
        public NoteType Type { get; set; }
    }
} 