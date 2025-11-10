using Biblioteca.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.DTOs
{
    public class EditorialLibroResponseDto
    {
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public int AnioPublicacion { get; set; }
        public GeneroLibro Genero { get; set; }
    }
}
