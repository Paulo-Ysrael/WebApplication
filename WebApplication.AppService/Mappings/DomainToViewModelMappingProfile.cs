using AutoMapper;
using WebApplication.Application.ViewModel.Response;
using WebApplication.Domain.Entity;

namespace WebApplication.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Members, MembersResponse>();
            CreateMap<Company, CompanyResponse>();
        }
    }
}
