using System.ComponentModel.DataAnnotations;

namespace TodoAppCore.Models
{
    public class AddTodoModel
    {
        [Required]
        public string Title { get; set; }
        [Required, DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
