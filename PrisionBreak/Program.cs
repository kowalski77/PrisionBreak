using PrisionBreak;

Console.WriteLine("Prision Break");

var firstScenario = Enumerable.Range(1, 100).ToScrumbled(FindStrategy.Random);
ExecuteScenario(firstScenario);

var secondScenario = Enumerable.Range(1, 100).ToScrumbled(FindStrategy.Own);
ExecuteScenario(secondScenario);

static void ExecuteScenario(IScrumbled<Box> boxContainer)
{
    var results = new List<bool>();
    Parallel.For(0, 1000, (_) =>
    {
        var result = boxContainer.Scrumble().IsScenarioSuccess();
        lock (results)
        {
            results.Add(result);
        }
    });

    var success = results.Count(x => x);
    var failures = results.Count(x => !x);
    var ratio = (double)success / failures * 100;

    Console.WriteLine($"Success: {success}, Failures: {failures}, Ratio: {ratio} %");
}
