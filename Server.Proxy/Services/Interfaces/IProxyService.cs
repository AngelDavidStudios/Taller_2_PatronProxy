using Server.Models.Models;

namespace Server.Proxy.Services.Interfaces;

public interface IProxyService
{
    public Task<IEnumerable<Heroes>> GetHeroesAsync();
    public Task<Heroes> GetHeroByIdAsync(int id);
    public Task<Heroes> AddHeroAsync(Heroes hero);
    public Task<Heroes> UpdateHeroAsync(Heroes hero);
    public Task<string> DeleteHeroAsync(int id);
}