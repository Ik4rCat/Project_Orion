using System.ComponentModel.DataAnnotations;

namespace Orion.Web.Models.Group
{
    public class CreateGroupViewModel
    {
        [Required(ErrorMessage = "Название группы обязательно")]
        [StringLength(100, ErrorMessage = "Название группы не может быть длиннее 100 символов")]
        [Display(Name = "Название группы")]
        public string Name { get; set; } = null!;

        [Display(Name = "Описание")]
        [StringLength(500, ErrorMessage = "Описание не может быть длиннее 500 символов")]
        public string? Description { get; set; }

        [Display(Name = "URL аватара")]
        [Url(ErrorMessage = "Некорректный URL")]
        public string? AvatarUrl { get; set; }
    }
} 