using Taller_2_PatronProxy.Models;

namespace Taller_2_PatronProxy.Repository.Interfaces;

public interface IHeroRepository
{
    Task<IEnumerable<Heroes>> GetHeroes();
    Task<Heroes> GetHerobyId(int id);
    Task AddHero(Heroes hero);
    Task UpdateHero(Heroes hero);
    Task DeleteHero(int id);
}