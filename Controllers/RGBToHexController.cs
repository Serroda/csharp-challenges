/* 
The rgb function is incomplete. Complete it so that passing in RGB decimal values will result in a hexadecimal representation being returned. Valid decimal values for RGB are 0 - 255. Any values that fall out of that range must be rounded to the closest valid value.

Note: Your answer should always be 6 characters long, the shorthand with 3 will not work here.
Examples (input --> output):

255, 255, 255 --> "FFFFFF"
255, 255, 300 --> "FFFFFF"
0, 0, 0       --> "000000"
148, 0, 211   --> "9400D3"

https://www.codewars.com/kata/513e08acc600c94f01000001
*/
using challenges.Models;
using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RGBToHexController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Convert(ColorDto Color) => Ok(Format(Color.Red) + Format(Color.Green) + Format(Color.Blue));

        private static string Format(int value)
        {
            if (value >= 255)
            {
                return "FF";
            }
            else if (value <= 0)
            {
                return "00";
            }
            else
            {
                return value.ToString("X2");
            }

        }
    }
}