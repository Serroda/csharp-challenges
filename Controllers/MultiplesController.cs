using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    //https://www.codewars.com/kata/5390bac347d09b7da40006f6/train/csharp
    public class MultiplesController : ControllerBase
    {
        [HttpGet("{value}")]
        public ActionResult<int> Get(int value)
        {
            int sum = 0;
            for (int i = 1; i < value; i++ )
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            return Ok(sum);
        }
    }
}