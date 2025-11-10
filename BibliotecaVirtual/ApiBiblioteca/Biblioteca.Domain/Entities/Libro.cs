using Biblioteca.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public int EditorialId { get; set; }
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public int AnioPublicacion { get; set; }
        public GeneroLibro Genero { get; set; }
    }
}
