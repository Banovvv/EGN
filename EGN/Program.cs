using EGN.Models;
var generator = new Egn();
var egn = generator.Generate(1892, 6, 18, "Ловеч", true, 2);
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine(egn);
Console.WriteLine(new string('-', 10));
Console.WriteLine(generator.GetInfo(egn));
