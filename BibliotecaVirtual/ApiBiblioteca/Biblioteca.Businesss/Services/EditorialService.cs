using AutoMapper;
using Biblioteca.Domain.DTOs;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Businesss.Services
{
    public class EditorialService(IEditorialRepository editorialRepository, IMapper mapper): IEditorialService
    {
        public readonly IEditorialRepository _editorialRepository = editorialRepository;
        public readonly IMapper _mapper = mapper;

        public async Task<EditorialResponseDto> CrearEditorialAsync(CreateEditorialDto editorial)
        {
            //Validacion de negocio
            if (editorial.Libros == null || !editorial.Libros.Any())
            {
                throw new ArgumentException("La editorial debe tener al menos un libro asociado.");
            }
            //Crear la editorial
            var editorialCreate = new Editorial
            {
                Nombre = editorial.Nombre,
                Pais = editorial.Pais,
                FechaRegistro = DateTime.UtcNow,
                Libros = editorial.Libros.Select(l => new Libro
                {
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    AnioPublicacion = l.AnioPublicacion,
                    Genero = l.Genero
                }).ToList()
            };
            //Logica de negocio: Calcular la cantidad de libros
            editorialCreate.CantidadLibros = editorial.Libros.Count;
            var createdEditorial = await _editorialRepository.CrearEditorialAsync(editorialCreate);
            return _mapper.Map<EditorialResponseDto>(createdEditorial);
        }

        public async Task<IEnumerable<EditorialResponseDto>> ObtenerTodasLasEditorialesAsync()
        {
            var editoriales = await _editorialRepository.ObtenerTodasLasEditorialesAsync();
            return _mapper.Map<IEnumerable<EditorialResponseDto>>(editoriales);
        }

        public async Task<EditorialResponseDto> ObtenerEditorialPorIdAsync(int editorialId)
        {
            var editorial = await _editorialRepository.ObtenerEditorialPorIdAsync(editorialId);
            if (editorial == null)
            {
                throw new KeyNotFoundException($"Editorial con ID {editorialId.ToString()} no encontrada.");
            }
            return _mapper.Map<EditorialResponseDto>(editorial);
        }
    }
}
