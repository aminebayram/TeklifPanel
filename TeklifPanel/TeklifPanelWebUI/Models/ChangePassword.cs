using System.ComponentModel.DataAnnotations;

namespace TeklifPanelWebUI.Models
{
    public class ChangePassword
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur!")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur!")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string RePassword { get; set; }
    }
}
