using Shop.Domain.UserAgg.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModel.Users
{
    public class EditUserViewModel
    {
        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name ="نام خوانوادگی")]
        [Required(ErrorMessage = "{0} راوارد کنید ")]
        public string FullName { get; set; }
        
        [Display(Name ="پست الکترونیکی")]
        [Required(ErrorMessage = "{0} را وارد کنید ")]
        public string Email { get; set; }
        
        [Display(Name ="شماره مبایل")]
        [Required(ErrorMessage ="{0} را وارد کنید ")]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "جنسیت")]
        public Gender Gender { get; set; } = Gender.None;
        
        [Display(Name ="تصویر پروفایل")]
        public IFormFile? Avatar { get;  set; }

    }
    public class EditUserModel
    {
        public long UserId { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0}را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "پست الکترونیکی")]
        [Required(ErrorMessage = "{0} را وارد کنید ")]
        public string Email { get; set; }

        [Display(Name = "شماره مبایل")]
        [Required(ErrorMessage = "{0} را وارد کنید ")]
        public string PhoneNumber { get; set; }

        [Display(Name = "جنسیت")]
        public Gender Gender { get; set; } = Gender.None;

        [Display(Name = "تصویر پروفایل")]
        public IFormFile? Avatar { get; set; }

    }
}
