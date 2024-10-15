using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
    public class User
    {
        public string Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "Usernam có độ dài tối thiểu là 2 ký tự")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Mật khẩu có độ dài tối thiểu là 4 ký tự")]
        public string Password { get; set; }
    }
}