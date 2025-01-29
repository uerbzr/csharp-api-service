using AutoMapper;
using System;
using workshop.data.models;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Calculation, CalculationDTO>();

        }
    }
}
