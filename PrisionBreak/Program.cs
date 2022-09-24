using PrisionBreak;

Console.WriteLine("--Prision Break--");

const int prisoners = 100;
var limit = prisoners / 2;
const int replay = 1000;

Console.WriteLine();
Console.WriteLine("Random strategy");
var randomScenario = Enumerable.Range(1, prisoners).ToScrumbled();
ExecuteScenario(randomScenario, replay);

Console.WriteLine();
Console.WriteLine("Loop strategy");
var loopScenario = Enumerable.Range(1, prisoners).ToScrumbledWithLoopStrategy();
ExecuteScenario(loopScenario, replay);

void ExecuteScenario(IScrumbled<Box> boxContainer, int replay)
{
    var results = new List<bool>();
    Parallel.For(0, replay, (_) =>
    {
        var result = boxContainer.Scrumble().IsScenarioSuccess(limit);
        lock (results)
        {
            results.Add(result);
        }
    });

    var success = results.Count(x => x);
    var failures = results.Count(x => !x);
    var ratio = (double)success / replay * 100;

    Console.WriteLine($"Success: {success}, Failures: {failures}, Ratio: {Math.Round(ratio, 2)} %");
}
