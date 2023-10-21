using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JadenStringController : ControllerBase
    {
        //https://www.codewars.com/kata/5390bac347d09b7da40006f6/train/csharp

        [HttpGet("{phrase}")]
        public ActionResult<string> CapitalizePhrase(string phrase)
        {
            StringBuilder result = new();
            bool capitalize = false;

            foreach (var item in phrase.Select((letter, index) => (letter, index)))
            {
                char finalChar = item.letter;

                if (capitalize || item.index == 0)
                {
                    capitalize = false;
                    finalChar = char.ToUpper(item.letter);
                }

                if (item.letter == ' ')
                {
                    capitalize = true;
                }

                result.Append(finalChar);
            }

            return Ok(result.ToString());
        }
    }
}