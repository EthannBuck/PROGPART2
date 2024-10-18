using System;
using System.ComponentModel.DataAnnotations;

namespace PROGPART1.Models
{
    public class Approval
    {
        [Key]
        public int ApprovalId { get; set; }

        [Required]
        public int ClaimId { get; set; }

        [Required]
        public int ApproverId { get; set; }

        public string Status { get; set; } 

        public string Comments { get; set; }

        public DateTime ApprovedAt { get; set; } = DateTime.Now;
    }
}
