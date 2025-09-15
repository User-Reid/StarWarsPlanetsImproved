using System.Text.Json;
using MockStarWarsData;

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

    var root = JsonSerializer.Deserialize<List<Result>>(json);
  }
}