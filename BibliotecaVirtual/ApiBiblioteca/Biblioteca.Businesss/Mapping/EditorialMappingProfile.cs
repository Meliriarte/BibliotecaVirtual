using AutoMapper;
using Biblioteca.Domain.DTOs;
using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Businesss.Mapping
{
    public class EditorialMappingProfile : Profile
    {
        public EditorialMappingProfile()
        {
            // Mapeo de Editorial a EditorialResponseDto
            CreateMap<Editorial, EditorialResponseDto>();

            // Mapeo de Libro a EditorialLibroResponseDto
            CreateMap<Libro, EditorialLibroResponseDto>()
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero.ToString()));
        }
    }
}
