using System.ComponentModel.DataAnnotations;

namespace identityCustomMvc.Models
{
    public class UserModelForRegister
    {
        [Required(ErrorMessage = "E-posta adresi belirtmelisiniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre belirtmelisiniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı belirtmelisiniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ad belirtmelisiniz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad belirtmelisiniz")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Yaş belirtmelisiniz")]
        [Range(1, int.MaxValue, ErrorMessage = "Yaşınız 0'dan büyük olmalı")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Konum belirtmelisiniz")]
        public string Location { get; set; }
    }
}