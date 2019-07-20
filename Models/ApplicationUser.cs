using Microsoft.AspNetCore.Identity;

namespace identityCustomMvc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
    }
}