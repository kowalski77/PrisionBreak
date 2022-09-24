using PrisionBreak;

Console.WriteLine("Prision Break");

var resultsLock = new object();
var results = new List<bool>();

var boxContainer = Enumerable.Range(1, 100).ToScrumbled();

Parallel.For(0, 1000, (_) =>
{
    var result = boxContainer.Scrumble().IsScenarioSuccess();
    lock (resultsLock)
    {
        results.Add(result);
    }
});

var success = results.Count(x => x);
var failures = results.Count(x => !x);

var ratio = (double)success / failures * 100;

Console.WriteLine($"Success ratio: {ratio} %");
