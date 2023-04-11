using System.ComponentModel.DataAnnotations;


namespace SchoolSystem.API.Domain.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
