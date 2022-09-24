using PrisionBreak;

Console.WriteLine("Prision Break");

var results = new List<bool>();
var boxContainer = Enumerable.Range(1, 100).ToScrumbled(FindStrategy.Own);

Parallel.For(0, 100, (_) =>
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

Console.WriteLine($"Success ratio: {ratio} %");
