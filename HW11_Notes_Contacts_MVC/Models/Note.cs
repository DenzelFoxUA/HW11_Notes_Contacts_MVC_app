using System.ComponentModel.DataAnnotations;

namespace HW11_Notes_Contacts_MVC.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(200)]
        public string Tags { get; set; }

    }
}
