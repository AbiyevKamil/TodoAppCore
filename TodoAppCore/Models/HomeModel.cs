using TodoAppCore.Entities;

namespace TodoAppCore.Models
{
    public class HomeModel
    {
        public AppUser AppUser { get; set; }
        public IEnumerable<Todo> Todos { get; set; }

    }
}
