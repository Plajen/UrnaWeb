using AutoMapper;
using UrnaEletronica.Application.ViewModels;
using UrnaEletronica.Domain.Models;

namespace UrnaEletronica.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Candidate, CandidateViewModel>();
            CreateMap<Vote, VoteViewModel>();
        }
    }
}
