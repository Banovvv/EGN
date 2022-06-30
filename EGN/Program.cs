using EGN.Models;
var generator = new Egn();
var egn = generator.Generate(1990, 1, 18, "Ловеч", true, 2);
Console.WriteLine(egn);
