using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Interfaces
{
    public interface IEditorialRepository
    {
        Task<Editorial> ObtenerEditorialPorIdAsync(int editorialId);
        Task<IEnumerable<Editorial>> ObtenerTodasLasEditorialesAsync();
        Task<Editorial> CrearEditorialAsync(Editorial editorial);
        Task ActualizarEditorialAsync(Editorial editorial);
        Task EliminarEditorialAsync(int editorialId);
    }
}
