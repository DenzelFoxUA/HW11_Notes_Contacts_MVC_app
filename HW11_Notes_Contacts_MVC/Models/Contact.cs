using System.ComponentModel.DataAnnotations;

namespace HW11_Notes_Contacts_MVC.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }

        public string ?PhoneAlternate { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
