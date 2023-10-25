
using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{

    public class Params
    {
        public required string FirstIp { get; set; }
        public required string SecondIp { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    //https://www.codewars.com/kata/526989a41034285187000de4
    public class CountIPController : ControllerBase
    {
        [HttpPost]
        public ActionResult<long> Calculate(Params Addresses)
        {

            int[] firstIp = Addresses.FirstIp
                            .Split(".")
                            .Select(int.Parse)
                            .ToArray();

            int[] secondIp = Addresses.SecondIp
                            .Split(".")
                            .Select(int.Parse)
                            .ToArray();

            double result = 0;
            
            for (int i = 0; i < firstIp.Length; i++)
            {
                result += Math.Pow(256 , firstIp.Length - (i + 1)) *
                            (secondIp[i] -  firstIp[i]);
            }

            return Ok(result);
        }
    }
}