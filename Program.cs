using System.Text.Json;

var taco = new Client();
var baseAddress = "https://swapi.info/api/";
var requestUri = "planets";

var json = await taco.Read(baseAddress, requestUri);
var root = JsonSerializer.Deserialize<List<Result>>(json);


System.Console.WriteLine("Press any key to close.");
Console.ReadKey();
