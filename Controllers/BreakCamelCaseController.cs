/* 
    Complete the solution so that the function will break up camel casing, using a space between words.
    Example

    "camelCasing"  =>  "camel Casing"
    "identifier"   =>  "identifier"
    ""             =>  "" 

    https://www.codewars.com/kata/5208f99aee097e6552000148
*/

using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BreakCamelCaseController : ControllerBase
    {
        [HttpGet("{phrase}")]
        public ActionResult<string> Break(string phrase) => Ok(new Regex("([A-Z])").Replace(phrase, " $1"));

    }
}