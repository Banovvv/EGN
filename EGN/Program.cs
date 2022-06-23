using EGN.Models;
var generator = new Egn();
var egn = generator.Generate(1990, 8, 10, "Ловеч", true);
Console.WriteLine(egn);
