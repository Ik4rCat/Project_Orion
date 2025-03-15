using System.ComponentModel.DataAnnotations;

namespace Orion.Web.Models.Account
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Поле Текущий пароль обязательно для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string CurrentPassword { get; set; } = null!;

        [Required(ErrorMessage = "Поле Новый пароль обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Пароль должен содержать не менее {2} символов", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение нового пароля")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; } = null!;
    }
} 