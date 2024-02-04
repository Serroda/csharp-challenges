// Alright, detective, one of our colleagues successfully observed our target person, Robby the robber. We followed him to a secret warehouse, where we assume to find all the stolen stuff. The door to this warehouse is secured by an electronic combination lock. Unfortunately our spy isn't sure about the PIN he saw, when Robby entered it.
//
// The keypad has the following layout:
//
// ┌───┬───┬───┐
// │ 1 │ 2 │ 3 │
// ├───┼───┼───┤
// │ 4 │ 5 │ 6 │
// ├───┼───┼───┤
// │ 7 │ 8 │ 9 │
// └───┼───┼───┘
//     │ 0 │
//     └───┘
//
// He noted the PIN 1357, but he also said, it is possible that each of the digits he saw could actually be another adjacent digit (horizontally or vertically, but not diagonally). E.g. instead of the 1 it could also be the 2 or 4. And instead of the 5 it could also be the 2, 4, 6 or 8.
//
// He also mentioned, he knows this kind of locks. You can enter an unlimited amount of wrong PINs, they never finally lock the system or sound the alarm. That's why we can try out all possible (*) variations.
//
// * possible in sense of: the observed PIN itself and all variations considering the adjacent digits
//
// Can you help us to find all those variations? It would be nice to have a function, that returns an array (or a list in Java/Kotlin and C#) of all variations for an observed PIN with a length of 1 to 8 digits. We could name the function getPINs (get_pins in python, GetPINs in C#). But please note that all PINs, the observed one and also the results, must be strings, because of potentially leading '0's. We already prepared some test cases for you.
//
// Detective, we are counting on you!
//
// For C# user: Do not use Mono. Mono is too slower when run your code.
//
// https://www.codewars.com/kata/5263c6999e0f40dee200059d/train/csharp

using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ObserverPinController : ControllerBase
    {
        [HttpGet("{observed}")]
        public ActionResult<IEnumerable<String>> GetPINs(string observed)
        {
            IEnumerable<int> possibleNumbers = GetPossiblesNumbers(observed);

            List<string> permutation = new List<string>();

            FillPermutation(possibleNumbers, permutation, observed.Length);

            return Ok(permutation);
        }

        private IEnumerable<int> GetPossiblesNumbers(string observed)
        {

            foreach (char item in observed)
            {
                int possibility = (int)char.GetNumericValue(item);
                int positionX = getPositionX(possibility);

                yield return possibility;

                if (possibility == 0)
                {
                    yield return (8);
                    continue;
                }

                if (possibility - 3 > 0)
                {
                    yield return (possibility - 3);
                }

                if (positionX - 1 > 0)
                {
                    yield return (possibility - 1);
                }

                if (positionX + 1 <= 3)
                {
                    yield return (possibility + 1);
                }

                if (possibility + 3 <= 9)
                {
                    yield return (possibility + 3);
                }

                if (possibility == 8)
                {
                    yield return (0);
                }

            }


        }

        private int getPositionX(int number)
        {
            int rest = 0;

            if (number > 3 && number < 6)
            {
                rest = 3;
            }
            else if (number > 6 && number < 9)
            {
                rest = 6;
            }

            return number - rest;

        }

        private void FillPermutation(IEnumerable<int> possibilities, List<string> permutation, int combinations, string lastValue = "")
        {
            if (combinations == lastValue.Length)
            {

                if (!permutation.Contains(lastValue)) { permutation.Add(lastValue); }
                return;
            }

            for (int i = 0; i < possibilities.Count(); i++)
            {
                FillPermutation(possibilities, permutation, combinations, new string(lastValue + possibilities.ElementAt(i).ToString()));
            }
         
        }
    }
}
