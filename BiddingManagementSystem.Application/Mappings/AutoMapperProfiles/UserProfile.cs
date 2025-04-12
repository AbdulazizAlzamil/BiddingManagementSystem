using AutoMapper;
using BiddingManagementSystem.Application.Features.Authentication.Commands.RegisterUser;
using BiddingManagementSystem.Domain.Aggregates.UserAggregate;
using BiddingManagementSystem.Domain.ValueObjects;

namespace BiddingManagementSystem.Application.Mappings.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserCommand, User>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address(
                   src.Street,
                   src.City,
                   src.State,
                   src.PostalCode,
                   src.Country
                )));
        }
    }
}

