using System.ComponentModel.DataAnnotations;


namespace challenges.Models
{
    public class RangeDto
    {
        [Required]
        public required int[] Serie {get; set;}
    }
}