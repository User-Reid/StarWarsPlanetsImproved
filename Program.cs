using System.Text.Json;

var taco = new Client();
var baseAddress = "https://swapi.info/api/";
var requestUri = "planets";

var json = await taco.Read(baseAddress, requestUri);
var data = JsonSerializer.Deserialize<List<Root>>(json);

foreach (var planet in data)
{
  System.Console.WriteLine($"{planet.name}");
}

Console.ReadKey();
