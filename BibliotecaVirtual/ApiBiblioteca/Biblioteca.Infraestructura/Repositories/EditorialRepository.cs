using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infraestructura.Repositories
{
    public class EditorialRepository(AppDbContext appDbContext) : IEditorialRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task ActualizarEditorialAsync(Editorial editorial)
        {
            _appDbContext.Editoriales.Update(editorial);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Editorial> CrearEditorialAsync(Editorial editorial)
        {
            _appDbContext.Editoriales.Add(editorial);
            await _appDbContext.SaveChangesAsync();
            return editorial;
        }

        public async Task EliminarEditorialAsync(int editorialId)
        {
            var editorial = await _appDbContext.Editoriales.FindAsync(editorialId);
            if (editorial != null)
            {
                _appDbContext.Editoriales.Remove(editorial);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Editorial> ObtenerEditorialPorIdAsync(int editorialId)
        {
            var editorial = await _appDbContext.Editoriales.Include(e => e.Libros).FirstOrDefaultAsync(e => e.Id == editorialId);
            return editorial!;
        }

        public async Task<IEnumerable<Editorial>> ObtenerTodasLasEditorialesAsync()
        {
            return await _appDbContext.Editoriales.Include(e => e.Libros).ToListAsync();
        }
    }
}
