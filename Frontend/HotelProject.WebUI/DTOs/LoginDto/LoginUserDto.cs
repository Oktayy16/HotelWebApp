using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifreyi Giriniz")]
        public string Password { get; set; }
    }
}
