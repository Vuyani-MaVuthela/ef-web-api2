namespace ef_web_api.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SuperHero, GetSuperHeroDto>();
            CreateMap<AddSuperHeroDto, SuperHero>();
            CreateMap<UpdateSuperHeroDto, SuperHero>();
        }
    }
}
