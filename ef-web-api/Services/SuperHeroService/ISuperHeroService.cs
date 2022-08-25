namespace ef_web_api.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<ServiceResponse<List<SuperHero>>> GetSuperHeroes();
        Task<ServiceResponse<SuperHero>> GetSuperHeroById(int id);
        Task<ServiceResponse<SuperHero>> AddSuperHero(SuperHero newSuperHero);
        Task<ServiceResponse<SuperHero>> UpdateSuperHero(SuperHero newSuperHero);
        //void DeleteSuperHero(int id);
    }
}
