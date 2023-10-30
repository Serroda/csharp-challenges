using System.ComponentModel.DataAnnotations;

namespace challenges.Models
{
    public class ColorDto
    {
        [Required]
        public int Red { get; set; }
        [Required]
        public int Green { get; set; }
        [Required]
        public int Blue { get; set; }
    }
}