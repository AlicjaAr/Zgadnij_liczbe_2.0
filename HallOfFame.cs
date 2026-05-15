using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgadnij_liczbe
{
    public class HallOfFame
    {
        private List<Result> results = new List<Result>();

        public void AddResult(Result result)
        {
            results.Add(result);

            results = results
                .OrderBy(r => r.Attempts)
                .ThenBy(r => r.TimeInSeconds)
                .ToList();
        }

        public void ShowResults()
        {
            foreach (Result result in results.Take(5))
            {
                Console.WriteLine(
                    $"{result.PlayerName} | {result.Attempts} | {result.TimeInSeconds}s");
            }
        }
    }
}
