using System.ComponentModel.DataAnnotations;

namespace TaskTrackerApi.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public void Update(TaskDto dto)
        {
            Title = dto.Title;
            Description = dto.Description;
            UpdatedDate = DateTime.Now;
        }
    }
}
