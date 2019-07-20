using System.ComponentModel.DataAnnotations;

namespace identityCustomMvc.Models
{
    public class UserModelForResetPassword
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Şifre belirtmelisiniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}