using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.DTOs
{
    public class EditorialResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public int CantidadLibros { get; set; }
        public List<EditorialLibroResponseDto> Libros { get; set; } = null!;
    }
}
