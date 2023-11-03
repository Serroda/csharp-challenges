using System.ComponentModel.DataAnnotations;

namespace challenges.Models
{
    public class IntervalsDto
    { 
        [Required]
        public required int[][] Series {get; set;}
        
    }

}