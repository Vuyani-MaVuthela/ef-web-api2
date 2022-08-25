using Microsoft.AspNetCore.Mvc;

namespace ef_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            this.superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<SuperHero>>>> Get()
        {
            return Ok(await superHeroService.GetSuperHeroes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<SuperHero>>> Get(int id)
        {
            return Ok(await superHeroService.GetSuperHeroById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<SuperHero>>>> AddSuperHero(SuperHero superHero)
        {
            return Ok(await superHeroService.AddSuperHero(superHero));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<SuperHero>>> UpdateHero(SuperHero superHero)
        {
            return Ok(await superHeroService.UpdateSuperHero(superHero));
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<ServiceResponse<SuperHero>> Delete(int id)
        //{
        //    var hero = await superHeroContext.SuperHeroes.FindAsync(id);
        //    if (hero == null)
        //        return NotFound("Hero does not exist");

        //    superHeroContext.SuperHeroes.Remove(hero);
        //    await superHeroContext.SaveChangesAsync();
        //    return Ok();
        //}
    }
}
