// See https://aka.ms/new-console-template for more information
using PrisionBreak;

Console.WriteLine("Hello, World!");

var playground = new BoxContainer(100);
playground.Scramble();

var path = playground.FindPath(32);

Console.ReadLine();

