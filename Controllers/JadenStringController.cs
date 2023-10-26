/*    

Jaden Smith, the son of Will Smith, is the star of films such as The Karate Kid (2010) and After Earth (2013). Jaden is also known for some of his philosophy that he delivers via Twitter. When writing on Twitter, he is known for almost always capitalizing every word. For simplicity, you'll have to capitalize each word, check out how contractions are expected to be in the example below.

Your task is to convert strings to how they would be written by Jaden Smith. The strings are actual quotes from Jaden Smith, but they are not capitalized in the same way he originally typed them.

Example:

Not Jaden-Cased: "How can mirrors be real if our eyes aren't real"
Jaden-Cased:     "How Can Mirrors Be Real If Our Eyes Aren't Real" 

https://www.codewars.com/kata/5390bac347d09b7da40006f6
*/
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class JadenStringController : ControllerBase
    {

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