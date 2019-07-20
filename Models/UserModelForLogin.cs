using System.ComponentModel.DataAnnotations;

namespace identityCustomMvc.Models
{
    public class UserModelForLogin
    {
        [Required(ErrorMessage = "Kullanıcı Adı belirtmelisiniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage= "Şifre belirtmelisiniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}