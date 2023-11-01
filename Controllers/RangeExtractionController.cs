/*

A format for expressing an ordered list of integers is to use a comma separated list of either
individual integers or a range of integers denoted by the starting integer separated from the end integer in the range by a dash, '-'. The range includes all integers in the interval including both endpoints. It is not considered a range unless it spans at least 3 numbers. For example "12,13,15-17"

Complete the solution so that it takes a list of integers in increasing order and returns a correctly formatted string in the range format.

Example:

solution([-10, -9, -8, -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20]);
returns "-10--8,-6,-3-1,3-5,7-11,14,15,17-20"

https://www.codewars.com/kata/51ba717bb08c1cd60f00002f
*/

using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace challenges.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RangeExtractionController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Format(int[] args)
        {

            StringBuilder result = new();
            List<int> range = [];

            for (int i = 0; i < args.Length; i++)
            {
                int value = args[i];
                int? nextValue = ((i + 1) == args.Length) ? null : args[i + 1];

                if (value + 1 == nextValue)
                {
                    range.Add(value);
                    continue;
                }
                else if (range.Count >= 2)
                {
                    result.Append(range.First().ToString() + '-' + value.ToString());
                    range.RemoveRange(0, range.Count);
                }
                else if(range.Count != 0){
                    result.Append(range.First().ToString() + ',' + value.ToString());
                    range.RemoveRange(0, range.Count);
                }
                else
                {
                    result.Append(value.ToString());
                }

                if((i + 1) != args.Length) {
                    result.Append(',');
                }
            }

            return result.ToString();
        }
    }
}