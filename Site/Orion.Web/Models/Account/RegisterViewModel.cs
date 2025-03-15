using System.ComponentModel.DataAnnotations;

namespace Orion.Web.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле Email обязательно для заполнения")]
        [EmailAddress(ErrorMessage = "Некорректный формат Email")]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Поле Имя обязательно для заполнения")]
        [Display(Name = "Имя")]
        [StringLength(50, ErrorMessage = "Имя должно содержать от {2} до {1} символов", MinimumLength = 2)]
        public string DisplayName { get; set; } = null!;

        [Required(ErrorMessage = "Поле Пароль обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Пароль должен содержать не менее {2} символов", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; } = null!;
    }
} 