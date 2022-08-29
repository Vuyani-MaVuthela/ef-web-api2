namespace ef_web_api.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<ServiceResponse<List<GetSuperHeroDto>>> GetSuperHeroes();
        Task<ServiceResponse<GetSuperHeroDto>> GetSuperHeroById(int id);
        Task<ServiceResponse<GetSuperHeroDto>> AddSuperHero(AddSuperHeroDto newSuperHero);
        Task<ServiceResponse<GetSuperHeroDto>> UpdateSuperHero(UpdateSuperHeroDto newSuperHero);
        Task<ServiceResponse<GetSuperHeroDto>> DeleteSuperHero(int id);
    }
}
