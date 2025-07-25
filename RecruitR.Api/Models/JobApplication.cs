﻿using System.ComponentModel.DataAnnotations;

namespace RecruitR.Api.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }
        public DateTime AppliedDate { get; set; }

        [Required]
        [RegularExpression("Applied|Interview|Rejected|Offer|Accepted", 
            ErrorMessage = "Status must be one of: Applied, Interview, Rejected, Offer, Accepted")]
        public string Status { get; set; } = "Applied";
    }
}
