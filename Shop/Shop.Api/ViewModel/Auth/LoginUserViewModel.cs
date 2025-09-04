using Common.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModel.Auth
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "شماره تلفن را وارد کنید")]
        [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        public string Password { get; set; }
    }
}
