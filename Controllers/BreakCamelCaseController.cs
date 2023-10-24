using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    //https://www.codewars.com/kata/5208f99aee097e6552000148
    public class BreakCamelCaseController : ControllerBase
    {
        [HttpGet("{phrase}")]
        public ActionResult<string> Break(string phrase) => Ok(new Regex("([A-Z])").Replace(phrase, " $1"));

    }
}