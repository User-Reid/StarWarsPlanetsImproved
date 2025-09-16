using System.Text.Json;
using MockStarWarsData;
using StarWarsPlanetsStats.DTOs;
using StarWarsPlanetsOriginal;

try
{

  await new StarWarsPlanetsStatsApp(new ApiDataReader()).Run();
}
catch (Exception ex)
{
  System.Console.WriteLine($"An error occured.\n Exception message {ex.Message}");
}

System.Console.WriteLine("Press any key to close.");
Console.ReadKey();

public class StarWarsPlanetsStatsApp
{
  private readonly IApiDataReader _apiDataReader;

  public StarWarsPlanetsStatsApp(IApiDataReader apiDataReader)
  {
    _apiDataReader = apiDataReader;
  }

  public async Task Run()
  {
    string json = null;
    try
    {
      var baseAddress = "https://swapi.info/api/";
      var requestUri = "planets";
      json = await _apiDataReader.Read(baseAddress, requestUri);
    }
    catch (HttpRequestException ex)
    {
      System.Console.WriteLine($"API request was unsucessful. \nSwitching to mock data.\nException message: {ex.Message}");
    }
    if (json is null)
    {
      // json = await _secondaryApiDataReader.Read(baseAddress, requestUri);
    }

    var root = JsonSerializer.Deserialize<List<Root>>(json);

    var planets = ToPlanets(root);
  }

  private IEnumerable<Planet> ToPlanets(IEnumerable<Root>? root)
  {
    if (root is null)
    {
      throw new ArgumentNullException(nameof(root));
    }

    var planets = new List<Planet>();

    foreach (var planetDto in root)
    {
      Planet planet =
      planets.Add(planet)
    }

    return planets;
  }
}

public readonly record struct Planet
{
  public string Name { get; }
  public int Diameter { get; }
  public int? SurfaceWater { get; }
  public int? Population { get; }

  public Planet(string name, int diameter, int? surfaceWater, int? population)
  {
    if (name is null)
    {
      throw new ArgumentNullException(nameof(name));
    }
    Name = name;
    Diameter = diameter;
    SurfaceWater = surfaceWater;
    Population = population;
  }
}