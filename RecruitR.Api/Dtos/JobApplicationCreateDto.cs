

using System.ComponentModel.DataAnnotations;

namespace RecruitR.Api.Dtos
{
    public class JobApplicationCreateDto
    {
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }

        [Required]
        [RegularExpression("Applied|Interview|Rejected|Offer|Accepted", 
            ErrorMessage = "Status must be one of: Applied, Interview, Rejected, Offer, Accepted")]
        public string Status { get; set; }

    }
}
