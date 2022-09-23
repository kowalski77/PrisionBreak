Console.WriteLine("Prision Break");

var prisoners = 100;

var boxContainer = Enumerable.Range(1, prisoners).ToBoxContainer();

var success = boxContainer.CheckPaths().IsSuccess();

Console.WriteLine($"Success: {success}");
