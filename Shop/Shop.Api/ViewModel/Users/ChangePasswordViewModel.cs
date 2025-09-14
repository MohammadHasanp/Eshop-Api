using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModel.Users
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "کلمه عبور فعلی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string CurrentPassword { get; set; }

        [Display(Name = "کلمه عبور فعلی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Compare(nameof(NewPassword), ErrorMessage = "کلمه های عبور یکسان نیستند")]
        public string ConfirmPassword { get; set; }
    }
}
