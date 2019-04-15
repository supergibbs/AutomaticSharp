using AutomaticSharp.Demo.Models;
using AutomaticSharp.Models;
using AutoMapper;

namespace AutomaticSharp.Demo.Config
{
    public static class AutoMapperConfig
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vehicle, VehicleViewModel>();
                cfg.CreateMap<Trip, TripViewModel>()
                    .ForMember(dest => dest.StartLocationName, action => action.MapFrom(src => src.StartAddress.DisplayName ?? src.StartAddress.Name ?? "Start Location"))
                    .ForMember(dest => dest.EndLocationName, action => action.MapFrom(src => src.EndAddress.DisplayName ?? src.EndAddress.Name ?? "End Location"))
                    .ForMember(dest => dest.Duration, action => action.MapFrom(src => src.Duration.HasValue ? src.Duration.Value.ToString("g") : null))
                    .ForMember(dest => dest.StartedAt, action => action.MapFrom(src => src.StartedAt.ToLocalTime().ToString("g")))
                    .ForMember(dest => dest.EndedAt, action => action.MapFrom(src => src.EndedAt.ToLocalTime().ToString("g")));
            });

            return config.CreateMapper();
        }
    }
}