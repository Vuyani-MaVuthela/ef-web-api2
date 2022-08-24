using Microsoft.AspNetCore.Mvc;

namespace ef_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private readonly SuperHeroContext superHeroContext;

        public SuperHeroController(SuperHeroContext superHeroContext)
        {
            this.superHeroContext = superHeroContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await superHeroContext.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await superHeroContext.SuperHeroes.FindAsync(id);
            if (hero == null)
                return NotFound("Hero does not exist");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero superHero)
        {
            superHeroContext.SuperHeroes.Add(superHero);
            await superHeroContext.SaveChangesAsync();
            return Ok(superHero);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero superHero)
        {
            superHeroContext.SuperHeroes.Update(superHero);
            await superHeroContext.SaveChangesAsync();
            return Ok(superHero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {
            var hero = await superHeroContext.SuperHeroes.FindAsync(id);
            if (hero == null)
                return NotFound("Hero does not exist");

            superHeroContext.SuperHeroes.Remove(hero);
            await superHeroContext.SaveChangesAsync();
            return Ok();
        }
    }
}
