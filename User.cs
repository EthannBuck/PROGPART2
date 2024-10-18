using System;
using System.ComponentModel.DataAnnotations;

namespace PROGPART1.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required, EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
