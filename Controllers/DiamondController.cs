using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiamondController : ControllerBase
    {
        //https://www.codewars.com/kata/5503013e34137eeeaa001648
        
        [HttpGet("{size}")]
        public ActionResult<string?> Generate(int size)
        {
            if (size % 2 == 0 || size < 0)
            {
                return BadRequest("Size must be odd");
            }

            StringBuilder result = new();

            int centerRow = (size / 2) + 1;

            for (int row = 1; row <= size; row++)
            {
                int spaces = centerRow - row;

                if (spaces < 0)
                {
                    spaces *= -1;
                }

                for (int space = 0; space < spaces; space++)
                {
                    result.Append(' ');
                }

                for (int diamond = 0; diamond < size - (spaces * 2); diamond++)
                {
                    result.Append('*');
                }

               result.Append('\n');
            }

            return Ok(result.ToString());
        }
    }
}