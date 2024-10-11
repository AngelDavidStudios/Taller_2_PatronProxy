using Microsoft.AspNetCore.Mvc;
using Taller_2_PatronProxy.Models;
using Taller_2_PatronProxy.Repository.Interfaces;

namespace Taller_2_PatronProxy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeroController: ControllerBase
{
    private readonly IHeroRepository _heroRepository;
    
    public HeroController(IHeroRepository heroRepository)
    {
        _heroRepository = heroRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Heroes>>> GetHeroes()
    {
        var heroes = await _heroRepository.GetHeroes();
        return Ok(heroes);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Heroes>> GetHeroById(int id)
    {
        var hero = await _heroRepository.GetHerobyId(id);
        return hero != null ? Ok(hero) : NotFound("Hero not found");
    }
    
    [HttpPost]
    public async Task<ActionResult<Heroes>> AddHero(Heroes hero)
    {
        if (hero != null)
        {
            await _heroRepository.AddHero(hero);
            return Ok(hero);
        }
        return BadRequest("Invalid Request");
    }
    
    [HttpPut]
    public async Task<ActionResult<Heroes>> UpdateHero(Heroes hero)
    {
        if (hero != null)
        {
            await _heroRepository.UpdateHero(hero);
            return Ok(hero);
        }
        return BadRequest("Invalid Request");
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Heroes>> DeleteHero(int id)
    {
        await _heroRepository.DeleteHero(id);
        return Ok("Hero deleted");
    }
}