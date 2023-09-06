using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TeklifPanelWebUI.Models
{
    public class RoleModel
    {
        [Required]
        public string Name { get; set; }
        public IdentityRole Role { get; set; }

    }
}
