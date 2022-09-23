using PrisionBreak;

Console.WriteLine("Prision Break");

var boxContainer = Enumerable.Range(1, 100).ToBoxContainer();

var results = new List<bool>();
Parallel.For(0, 100, (_) => results.Add(boxContainer.Scrumble().ScenarioSuccess()));

var success = results.Count(x => x);
var failures = results.Count(x => !x);

var ratio = (double)success / failures * 100;

Console.WriteLine($"Success ratio: {ratio} %");
