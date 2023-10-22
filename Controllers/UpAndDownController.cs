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


            List<string> words = [.. phrase.Split(" ")];

            for (int i = 0; i < words.Count; i++)
            {

                string word = words[i];

                for (int x = 0; x < words.Count; x++)
                {

                    switch (i)
                    {
                    //TODO
                    }
                }

            }


            return Ok(words.ToString());
        }
    }
}