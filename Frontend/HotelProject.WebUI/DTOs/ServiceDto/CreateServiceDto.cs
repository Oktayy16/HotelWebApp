using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Hizmet Icon Linki Giriniz")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet Başlığı Giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet Başlığı En Fazla 100 Karakter Olabilir")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
