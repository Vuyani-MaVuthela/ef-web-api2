using ef_web_api.Entities;
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
        public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> Get()
        {
            return Ok(await superHeroService.GetSuperHeroes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSuperHeroDto>>> Get(int id)
        {
            return Ok(await superHeroService.GetSuperHeroById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetSuperHeroDto>>> AddSuperHero(AddSuperHeroDto superHero)
        {
            return Ok(await superHeroService.AddSuperHero(superHero));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetSuperHeroDto>>> UpdateHero(UpdateSuperHeroDto superHero)
        {
            var response = await superHeroService.UpdateSuperHero(superHero);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSuperHeroDto>>> DeleteHero(int id)
        {
            var response = await superHeroService.DeleteSuperHero(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
