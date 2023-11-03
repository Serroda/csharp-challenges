/* 
Write a function called sumIntervals/sum_intervals that accepts an array of intervals, and returns the sum of all the interval lengths. Overlapping intervals should only be counted once.
Intervals

Intervals are represented by a pair of integers in the form of an array. The first value of the interval will always be less than the second value. Interval example: [1, 5] is an interval from 1 to 5. The length of this interval is 4.
Overlapping Intervals

List containing overlapping intervals:

[
   [1, 4],
   [7, 10],
   [3, 5]
]

The sum of the lengths of these intervals is 7. Since [1, 4] and [3, 5] overlap, we can treat the interval as [1, 5], which has a length of 4.
Examples:

sumIntervals( [
   [1, 2],
   [6, 10],
   [11, 15]
] ) => 9

sumIntervals( [
   [1, 4], 
   [7, 10], 
   [3, 5] 
] ) => 7

sumIntervals( [
   [5, 7], 
   [3, 6], 
   [8, 10] 
] ) => 6

sumIntervals( [
   [1, 5], => 4 => 0
   [10, 20], => 10
   [1, 6], => 5
   [16, 19], => 3 => 0
   [5, 11] => 6 => 4
] ) => 19

sumIntervals( [
   [0, 20],
   [-100000000, 10],
   [30, 40]
] ) => 100000030

sumIntervals( [
   [-7, 8], => 15
   [-2, 10], => 8 => 2
   [5, 15], => 10 => 5
   [2000,3150], => 1150
   [-5400, -5338] => 62
] ) => 1234

Tests with large intervals

Your algorithm should be able to handle large intervals. All tested intervals are subsets of the range [-1000000000, 1000000000].
 
 https://www.codewars.com/kata/52b7ed099cdc285c300001cd
 */

using Microsoft.AspNetCore.Mvc;
using challenges.Models;

namespace challenges.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class SumIntervalsController : ControllerBase
   {
      [HttpPost]
      public ActionResult<int> Calculate(IntervalsDto args)
      {

         int result = 0;
         List<int[]> overlapingIntervals = [];

         for (int i = 0; i < args.Series.Length; i++)
         {
            int firstValue = args.Series[i][0];
            int secondValue = args.Series[i][1];

            List<int[]> matchs = args.Series
             .Where((item, index) =>
             index != i &&
            (firstValue >= item[0] &&
             firstValue <= item[1] ||
             secondValue >= item[0] &&
             secondValue <= item[1]) &&
            !overlapingIntervals.Contains(item))
             .ToList();

            result += secondValue - firstValue;

            if (matchs.Count != 0)
            {
               overlapingIntervals.Add(args.Series[i]);
               overlapingIntervals.AddRange(matchs);

               foreach (int[] match in matchs)
               {
                  if (firstValue == match[0] || secondValue == match[1])
                  {
                     result -= match[1] - match[0];
                  }
                  else if (firstValue > match[0] &&
                           firstValue < match[1])
                  {
                     if (firstValue - match[0] < match[1] - firstValue)
                     {
                        result -= firstValue - match[0];
                     }
                     else
                     {
                        result -= match[1] - firstValue;
                     }

                  }
                  else if (secondValue > match[0] &&
                            secondValue < match[1])
                  {
                     if (secondValue - match[0] < match[1] - secondValue)
                     {
                        result -= secondValue - match[0];
                     }
                     else
                     {
                        result -= match[1] - secondValue;
                     }
                  }
               }
            }
         }

         return Ok(result);
      }
   }
}