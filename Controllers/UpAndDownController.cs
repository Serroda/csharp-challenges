using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //https://www.codewars.com/kata/56cac350145912e68b0006f0

    public class UpAndDownController : ControllerBase
    {
        [HttpGet("{phrase}")]
        public ActionResult<string> OrderString(string phrase)
        {
            string[] words = phrase.Split(" ");

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                for (int x = i + 1; x < words.Length; x++)
                {
                    string compareWord = words[x];

                    if ((x - 1) % 2 == 0)
                    {
                        if (word.Length > compareWord.Length)
                        {
                            words[x - 1] = compareWord;
                            words[x] = word;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (word.Length < compareWord.Length)
                        {
                            words[x - 1] = compareWord;
                            words[x] = word;
                        }
                        else
                        {
                            break;
                        }
                    }


                }
            }

            return Ok(string.Join(" ", 
            words.Select((word, index) => (index % 2 == 0) ? word.ToLower() : word.ToUpper())));
        }
    }
}