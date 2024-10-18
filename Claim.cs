using System.ComponentModel.DataAnnotations;

namespace PROGPART1.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hours worked is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Hours worked must be a positive number.")]
        public int HoursWorked { get; set; }

        [Required(ErrorMessage = "Hourly rate is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Hourly rate must be a positive number.")]
        public decimal HourlyRate { get; set; }

        public string Notes { get; set; }

        public string SupportingDocumentPath { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
