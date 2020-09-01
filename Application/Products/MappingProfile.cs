using AutoMapper;
using Domain;

namespace Application.Products
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductReturnDto>()
                .ForMember(x => x.Category,
                    o => o.MapFrom(x => x.Category.Name));
        }
    }
}