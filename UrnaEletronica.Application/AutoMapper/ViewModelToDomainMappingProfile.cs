using AutoMapper;
using UrnaEletronica.Application.ViewModels;
using UrnaEletronica.Domain.Models;

namespace UrnaEletronica.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CandidateViewModel, Candidate>();
            CreateMap<VoteViewModel, Vote>();
        }
    }
}
