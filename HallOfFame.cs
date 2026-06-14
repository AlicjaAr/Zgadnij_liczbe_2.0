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
            ShowDifficultyResults(Difficulty.Easy);
            ShowDifficultyResults(Difficulty.Medium);
            ShowDifficultyResults(Difficulty.Hard);
        }

        private void ShowDifficultyResults(Difficulty difficulty)
        {
            Console.WriteLine($"=== {difficulty.ToString().ToUpper()} ===");

            var filteredResults = results
                .Where(r => r.Difficulty == difficulty)
                .Take(5);

            foreach (Result result in filteredResults)
            {
                string name = result.PlayerName;

                if (result.IsNewGamePlus)
                {
                    name += " (NG+)";
                }

                Console.WriteLine($"{name} - {result.Attempts} {Messages.Get("Attempts")} - {result.TimeInSeconds}s");
            }

            Console.WriteLine();
        }
        public void ClearResults()
        {
            results.Clear();
        }
        public bool HasResults()
        {
            return results.Count > 0;
        }
    }
}
