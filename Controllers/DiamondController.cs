/*         
    Jamie is a programmer, and James' girlfriend. She likes diamonds, and wants a diamond string from James. Since James doesn't know how to make this happen, he needs your help.
    Task

    You need to return a string that looks like a diamond shape when printed on the screen, using asterisk (*) characters. Trailing spaces should be removed, and every line must be terminated with a newline character (\n).

    Return null/nil/None/... if the input is an even number or negative, as it is not possible to print a diamond of even or negative size.
    Examples

    A size 3 diamond:

     *
    ***
     *

    ...which would appear as a string of " *\n***\n *\n"

    A size 5 diamond:

         *
        ***
       *****
        ***
         *

    ...that is:

    "  *\n ***\n*****\n ***\n  *\n"

    https://www.codewars.com/kata/5503013e34137eeeaa001648
*/

using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DiamondController : ControllerBase
    {
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