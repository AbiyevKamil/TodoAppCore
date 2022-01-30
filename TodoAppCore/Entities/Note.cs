using System.ComponentModel.DataAnnotations;

namespace TodoAppCore.Entities
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
