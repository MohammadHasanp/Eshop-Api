using Common.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModel.Auth
{
    public class LoginUserViewModel
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
