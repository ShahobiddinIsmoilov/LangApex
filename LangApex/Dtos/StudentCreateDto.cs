using System.ComponentModel.DataAnnotations;

namespace LangApex.Dtos
{
    public class StudentCreateDto
    {
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(9)]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? CourseDays { get; set; }

        [Required]
        public string? CourseTime { get; set; }

        [Required]
        [MaxLength(25)]
        public string? Teacher { get; set; }
    }
}
