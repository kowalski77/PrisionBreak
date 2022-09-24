using PrisionBreak;

Console.WriteLine("Prision Break");

Console.WriteLine("Random strategy");
var loopScenario = Enumerable.Range(1, 100).ToScrumbled();
ExecuteScenario(loopScenario);

Console.WriteLine("Loop strategy");
var randomScenario = Enumerable.Range(1, 100).ToScrumbledWithLoopStrategy();
ExecuteScenario(randomScenario);

static void ExecuteScenario(IScrumbled<Box> boxContainer)
{
    const int replay = 1000;
    var results = new List<bool>();
    Parallel.For(0, replay, (_) =>
    {
        var result = boxContainer.Scrumble().IsScenarioSuccess();
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
