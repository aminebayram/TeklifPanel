using Microsoft.AspNetCore.Identity;
using TeklifPanel.Entity;

namespace TeklifPanelWebUI.ViewModels
{
    public class UserViewModel
    {
        public List<User> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
