using System.ComponentModel.DataAnnotations;
using Orion.Core.Enums;

namespace Orion.Web.Models.Account
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Поле Имя обязательно для заполнения")]
        [Display(Name = "Имя")]
        [StringLength(50, ErrorMessage = "Имя должно содержать от {2} до {1} символов", MinimumLength = 2)]
        public string DisplayName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Некорректный формат Email")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "О себе")]
        [StringLength(500, ErrorMessage = "Информация о себе должна содержать не более {1} символов")]
        public string? Bio { get; set; }

        [Display(Name = "URL аватара")]
        [Url(ErrorMessage = "Некорректный URL")]
        public string? AvatarUrl { get; set; }

        [Display(Name = "Тема оформления")]
        public Theme Theme { get; set; }
    }
} 