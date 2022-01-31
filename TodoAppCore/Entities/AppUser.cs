using Microsoft.AspNetCore.Identity;

namespace TodoAppCore.Entities
{
    public class AppUser : IdentityUser
    {
        public List<Todo> Todos { get; set; }
    }
}
