using System.ComponentModel.DataAnnotations;

namespace challenges.Models
{
    public class IpsDto
    {
        [Required]
        public required string FirstIp { get; set; }
        [Required]
        public required string SecondIp { get; set; }

    }
}