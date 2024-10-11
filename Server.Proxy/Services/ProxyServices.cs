using RestSharp;
using Server.Models.Models;
using Server.Proxy.Services.Interfaces;

namespace Server.Proxy.Services;

public class ProxyServices: IProxyService
{
    private readonly RestClient _restClient;

    public ProxyServices()
    {
        _restClient = new RestClient("http://localhost:5094/api");
    }

    public async Task<IEnumerable<Heroes>> GetHeroesAsync()
    {
        var request = new RestRequest("Hero", Method.Get);
        var response = await _restClient.ExecuteAsync<IEnumerable<Heroes>>(request);
            
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        {
            return Enumerable.Empty<Heroes>();
        }
            
        return response.Data;
    }

    public async Task<Heroes> GetHeroByIdAsync(int id)
    {
        var request = new RestRequest($"Hero/{id}", Method.Get);
        var response = await _restClient.ExecuteAsync<Heroes>(request);
        return response.Data;
    }

    public async Task<Heroes> AddHeroAsync(Heroes hero)
    {
        var request = new RestRequest("Hero", Method.Get);
        request.AddJsonBody(hero);
        var response = await _restClient.ExecuteAsync<Heroes>(request);
        return response.Data;
    }

    public async Task<Heroes> UpdateHeroAsync(Heroes hero)
    {
        var request = new RestRequest("Hero", Method.Put);
        request.AddJsonBody(hero);
        var response = await _restClient.ExecuteAsync<Heroes>(request);
        return response.Data;
    }

    public async Task<string> DeleteHeroAsync(int id)
    {
        var request = new RestRequest($"Hero/{id}", Method.Delete);
        var response = await _restClient.ExecuteAsync(request);
        return response.Content;
    }
}