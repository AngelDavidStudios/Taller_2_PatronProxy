using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Taller_2_PatronProxy.Data;
using Taller_2_PatronProxy.Models;
using Taller_2_PatronProxy.Repository.Interfaces;

namespace Taller_2_PatronProxy.Repository;

public class HeroRepository: IHeroRepository
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _cache;
    
    public HeroRepository(AppDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }
    
    public async Task<IEnumerable<Heroes>> GetHeroes()
    {
        string cacheKey = "Heroes";
        if (!_cache.TryGetValue(cacheKey, out IEnumerable<Heroes> heroes))
        {
            heroes = await _context.Heroes.ToListAsync();
            _cache.Set(cacheKey, heroes, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
            _cache.Set(cacheKey, heroes);
        }
        return heroes;
    }
    
    public async Task<Heroes> GetHerobyId(int id)
    {
        string cacheKey = "Hero" + id;
        if (!_cache.TryGetValue(cacheKey, out Heroes hero))
        {
            hero = await _context.Heroes.FindAsync(id);
            _cache.Set(cacheKey, hero, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
            _cache.Set(cacheKey, hero);
        }
        return hero;
    }
    
    public async Task AddHero(Heroes hero)
    {
        await _context.Heroes.AddAsync(hero);
        await _context.SaveChangesAsync();
        _cache.Remove("Heroes");
    }
    
    public async Task UpdateHero(Heroes hero)
    {
        _context.Entry(hero).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        _cache.Remove("Heroes");
        _cache.Remove("Hero" + hero.Hero_Id);
    }
    
    public async Task DeleteHero(int id)
    {
        var hero = await _context.Heroes.FindAsync(id);
        _context.Heroes.Remove(hero);
        await _context.SaveChangesAsync();
        
        _cache.Remove("Heroes");
        _cache.Remove("Hero" + id);
    }
}