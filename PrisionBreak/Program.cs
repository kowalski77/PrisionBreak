using PrisionBreak;

Console.WriteLine("--Prision Break--");

const int prisoners = 100;
const int replay = 10_000;
var limit = prisoners / 2;

Console.WriteLine();
Console.WriteLine("Random strategy");
var randomBoxScenario = Enumerable.Range(1, prisoners).ToScrumbled();
ExecuteScenario(randomBoxScenario, replay);

Console.WriteLine();    
Console.WriteLine("Own box strategy");
var ownBoxScenario = Enumerable.Range(1, prisoners).ToScrumbledWithOwnBoxStrategy();
ExecuteScenario(ownBoxScenario, replay);


void ExecuteScenario(IScrumbled<Box> boxContainer, int replay)
{
    var results = new List<bool>();
    Parallel.For(0, replay, (_) =>
    {
        var result = boxContainer.Scrumble().RunAll().Success(limit);
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
