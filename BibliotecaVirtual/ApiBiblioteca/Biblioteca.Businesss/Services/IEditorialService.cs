using Biblioteca.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Businesss.Services
{
    public interface IEditorialService
    {
        Task<EditorialResponseDto> CrearEditorialAsync(CreateEditorialDto editorial);
        Task<IEnumerable<EditorialResponseDto>> ObtenerTodasLasEditorialesAsync();
        Task<EditorialResponseDto> ObtenerEditorialPorIdAsync(int editorialId);
    }
}
