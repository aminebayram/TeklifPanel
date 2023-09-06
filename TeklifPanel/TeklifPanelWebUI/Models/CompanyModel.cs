using System.ComponentModel.DataAnnotations;

namespace TeklifPanelWebUI.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = ("Şifreler uyuşmuyor!"))]
        public string RePassword { get; set; }
    }
}
  