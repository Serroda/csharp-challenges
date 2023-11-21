
using System.ComponentModel.DataAnnotations;

namespace challenges.Models
{
    public class TextDTO
    {
        [Required]
        public required string Text {get; set;}
    }
}