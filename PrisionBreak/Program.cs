using PrisionBreak;

Console.WriteLine("Prision Break");

var prisoners = 100;

var success = Enumerable.Range(1, prisoners)
    .ToBoxContainer()
    .Scrumble()
    .ScenarioSuccess();

Console.WriteLine($"Success: {success}");
