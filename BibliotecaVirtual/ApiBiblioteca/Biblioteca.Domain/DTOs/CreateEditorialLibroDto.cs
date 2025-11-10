using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Domain.Enums;

namespace Biblioteca.Domain.DTOs
{
    public class CreateEditorialLibroDto
    {
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public int AnioPublicacion { get; set; }
        public GeneroLibro Genero { get; set; }
    }
}
