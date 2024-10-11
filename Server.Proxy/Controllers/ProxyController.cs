using Microsoft.AspNetCore.Mvc;
using Server.Models.Models;
using Server.Proxy.Services.Interfaces;

namespace Server.Proxy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProxyController: ControllerBase
{
    private readonly IProxyService _proxyService;
    
    public ProxyController(IProxyService proxyService)
    {
        _proxyService = proxyService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Heroes>>> GetHeroes()
    {
        var heroes = await _proxyService.GetHeroesAsync();
        return Ok(heroes);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Heroes>> GetHeroById(int id)
    {
        var hero = await _proxyService.GetHeroByIdAsync(id);
        return hero != null ? Ok(hero) : NotFound("Hero not found");
    }
    
    [HttpPost]
    public async Task<ActionResult<Heroes>> AddHero(Heroes hero)
    {
        if (hero != null)
        {
            await _proxyService.AddHeroAsync(hero);
            return Ok(hero);
        }
        return BadRequest("Invalid Request");
    }
    
    [HttpPut]
    public async Task<ActionResult<Heroes>> UpdateHero(Heroes hero)
    {
        if (hero != null)
        {
            await _proxyService.UpdateHeroAsync(hero);
            return Ok(hero);
        }
        return BadRequest("Invalid Request");
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Heroes>> DeleteHero(int id)
    {
        await _proxyService.DeleteHeroAsync(id);
        return Ok("Hero deleted");
    }
}