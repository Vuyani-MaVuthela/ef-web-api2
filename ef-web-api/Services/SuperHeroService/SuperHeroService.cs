using ef_web_api.Entities;

namespace ef_web_api.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>()
        {
             new SuperHero{
                Id= 3,
                Name= "Batman",
                FirstName= "Bruce",
                LastName= "Wayne",
                Place= "Gotham city"
                },
             new SuperHero{
                Id= 4,
                Name= "Spiderman",
                FirstName= "Peter",
                LastName= "Parker",
                Place= "New York City"
              }
        };

        public async Task<ServiceResponse<List<SuperHero>>> GetSuperHeroes()
        {
            var serviceResponse = new ServiceResponse<List<SuperHero>>();
            serviceResponse.Data = superHeroes;
            return serviceResponse;
            //return new ServiceResponse<List<SuperHero>> { Data = superHeroes };
        }

        public async Task<ServiceResponse<SuperHero>> GetSuperHeroById(int id)
        {
            SuperHero superHero = superHeroes.FirstOrDefault(x => x.Id == id);
            var serviceResponse = new ServiceResponse<SuperHero>();
            serviceResponse.Data = superHero;
            return serviceResponse;
        }

        public async Task<ServiceResponse<SuperHero>> AddSuperHero(SuperHero superHero)
        {
            superHeroes.Add(superHero);
            var serviceResponse = new ServiceResponse<SuperHero>();
            serviceResponse.Data = superHero;
            return serviceResponse;
        }

        public async Task<ServiceResponse<SuperHero>> UpdateSuperHero(SuperHero newSuperHero)
        {
            var superHero = superHeroes.FirstOrDefault(x => x.Id == newSuperHero.Id);
            if (superHero == null)
            {
                return null;
            }
            superHero.Name = newSuperHero.Name;
            var serviceResponse = new ServiceResponse<SuperHero>();
            serviceResponse.Data = superHero;
            return serviceResponse;
        }
    }
}
