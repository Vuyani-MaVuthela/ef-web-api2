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

        private readonly IMapper mapper;

        public SuperHeroService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetSuperHeroDto>>> GetSuperHeroes()
        {
            return new ServiceResponse<List<GetSuperHeroDto>>
            {
                Data = superHeroes.Select(x => this.mapper.Map<GetSuperHeroDto>(x)).ToList()
            };
        }

        public async Task<ServiceResponse<GetSuperHeroDto>> GetSuperHeroById(int id)
        {
            SuperHero superHero = superHeroes.FirstOrDefault(x => x.Id == id);
            var serviceResponse = new ServiceResponse<GetSuperHeroDto>();
            serviceResponse.Data = this.mapper.Map<GetSuperHeroDto>(superHero);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSuperHeroDto>> AddSuperHero(AddSuperHeroDto newSuperHero)
        {
            var serviceResponse = new ServiceResponse<GetSuperHeroDto>();
            var superHero = this.mapper.Map<SuperHero>(newSuperHero);
            superHeroes.Add(superHero);
            serviceResponse.Data = this.mapper.Map<GetSuperHeroDto>(superHero);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSuperHeroDto>> UpdateSuperHero(UpdateSuperHeroDto superHeroEdit)
        {
            ServiceResponse<GetSuperHeroDto> serviceResponse = new ServiceResponse<GetSuperHeroDto>();
            try
            {
                SuperHero superHero = superHeroes.FirstOrDefault(x => x.Id == superHeroEdit.Id);
                if (superHero != null)
                {
                    //superHero.Name = superHeroEdit.Name; manually edit
                    this.mapper.Map(superHeroEdit, superHero);
                    serviceResponse.Data = this.mapper.Map<GetSuperHeroDto>(superHero);
                }
                else
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Not found";
                }
            }
            catch (Exception e)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSuperHeroDto>> DeleteSuperHero(int id)
        {
            ServiceResponse<GetSuperHeroDto> serviceResponse = new ServiceResponse<GetSuperHeroDto>();
            try
            {
                SuperHero superHero = superHeroes.FirstOrDefault(x => x.Id == id);
                if (superHero != null)
                {
                    serviceResponse.Data = this.mapper.Map<GetSuperHeroDto>(superHero);
                    superHeroes.Remove(superHero);
                }
                else
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Not found";
                }
            }
            catch (Exception e)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}
