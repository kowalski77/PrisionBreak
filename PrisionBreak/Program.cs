// See https://aka.ms/new-console-template for more information
using PrisionBreak;

Console.WriteLine("Hello, World!");

var prisoners = 100;
var boxContainer = new BoxContainer(prisoners, 50);
boxContainer.Scramble();

var results = new List<bool>();
for (var i = 1; i <= prisoners; i++)
{
    results.Add(boxContainer.CanFindPathBellowLimit(i));
}

var success = results.Count(x => x);
var failures = results.Count(x => !x);

var boxList = string.Join(Environment.NewLine, boxContainer);
Console.WriteLine(boxList);
Console.WriteLine($"Success: {success} - failures: {failures}");

