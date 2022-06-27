using EGN.Models;
var generator = new Egn();
var egn = generator.Generate(1990, 7, 10, "Ловеч", true);
Console.WriteLine(egn);
