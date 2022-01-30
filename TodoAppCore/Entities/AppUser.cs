using Microsoft.AspNetCore.Identity;

namespace TodoAppCore.Entities
{
    public class AppUser : IdentityUser
    {
        public List<Note> Notes { get; set; }
    }
}
