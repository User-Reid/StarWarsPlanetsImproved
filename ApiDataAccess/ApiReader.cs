public interface IApiDataReader
{
  public Task<string> Read(string baseAddress, string requestUri);
}
System.Console.WriteLine("");