using PrisionBreak;

Console.WriteLine("Prision Break");

var prisoners = 100;
var boxContainer = new BoxContainer(prisoners, 50);

var success = boxContainer.CheckPaths().IsSuccess();

Console.WriteLine($"Success: {success}");
