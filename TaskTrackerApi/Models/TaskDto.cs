using System.ComponentModel.DataAnnotations;

namespace TaskTrackerApi.Models
{
    public class TaskDto
    {
        [Required, MinLength(3), MaxLength(50)]
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
