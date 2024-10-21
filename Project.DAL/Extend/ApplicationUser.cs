using Microsoft.AspNetCore.Identity;

namespace Project.DAL.Extend
{
    public class ApplicationUser : IdentityUser
    {
        public bool IAgree { get; set; }
    }
}
