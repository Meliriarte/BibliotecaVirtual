using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.DTOs
{
    public class CreateEditorialDto
    {
        public string Nombre { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public List<CreateEditorialLibroDto> Libros { get; set; } = [];
    }
}
