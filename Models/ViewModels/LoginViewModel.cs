using System.ComponentModel.DataAnnotations;

namespace Shopping.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required, MinLength(2, ErrorMessage = "Usernam có độ dài tối thiểu là 2 ký tự")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Mật khẩu có độ dài là 4 ký tự")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}