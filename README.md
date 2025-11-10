# BibliotecaVirtual API

API  para la gestión de editoriales y sus libros asociados.

## Características Principales

*   **Gestión de Editoriales:** Creación, consulta por ID y listado de todas las editoriales.
*   **Creación de Libros Anidados:** Al crear una editorial, se pueden incluir uno o más libros asociados en la misma solicitud.
*   **Validación de Negocio:** Se asegura que cada editorial tenga al menos un libro asociado.
*   **Arquitectura Limpia (Onion Architecture):** Separación clara de responsabilidades en capas:
    *   `Biblioteca.Api`: Capa de presentación (Controladores).
    *   `Biblioteca.Businesss`: Capa de lógica de negocio (Servicios).
    *   `Biblioteca.Domain`: Capa de dominio (Entidades, DTOs, Interfaces de Repositorio).
    *   `Biblioteca.Infraestructura`: Capa de persistencia (Implementación de Repositorios, `DbContext`).

## Tecnologías Utilizadas

*   **Lenguaje:** C#
*   **Framework:** .NET 9.0 
*   **Web Framework:** ASP.NET Core Web API
*   **Base de Datos:** SQL Server 

## Configuración e Instalación

Sigue estos pasos para poner en marcha el proyecto en tu entorno local.

### Prerrequisitos

*   .NET SDK (versión 9.0 o superior)
*   Una instancia de SQL Server (o la base de datos configurada)

### Pasos

1.  **Clonar el Repositorio**
    ```bash
    git clone [URL_DEL_REPOSITORIO]
    cd BibliotecaVirtual/ApiBiblioteca
    ```

2.  **Restaurar Dependencias**
    ```bash
    dotnet restore
    ```

3.  **Configurar la Base de Datos**
    Asegúrate de que la cadena de conexión en `appsettings.json` de `Biblioteca.Api` apunte a tu base de datos.

4.  **Aplicar Migraciones**
    Ejecuta las migraciones de Entity Framework Core para crear el esquema de la base de datos:
    ```bash
    dotnet ef database update --project Biblioteca.Infraestructura
    ```

5.  **Ejecutar la API**
    ```bash
    dotnet run --project Biblioteca.Api
    ```
    La API estará disponible por defecto en `https://localhost:7000` (o el puerto configurado ).

## 🔗 Endpoints de la API

La API expone los siguientes endpoints para la gestión de editoriales:

| Método | Ruta | Descripción | Cuerpo de Solicitud (Request Body) | Respuesta (Response Body) |
| :--- | :--- | :--- | :--- | :--- |
| `POST` | `/api/Editoriales` | Crea una nueva editorial y sus libros. | `CreateEditorialDto` | `EditorialResponseDto` (201 Created) |
| `GET` | `/api/Editoriales/{id}` | Obtiene una editorial específica por su ID. | N/A | `EditorialResponseDto` (200 OK) |
| `GET` | `/api/Editoriales` | Obtiene el listado completo de editoriales. | N/A | `IEnumerable<EditorialResponseDto>` (200 OK) |

### Ejemplo de Solicitud POST

Para crear una nueva editorial con libros:

```json
{
  "nombre": "Editorial Planeta",
  "pais": "España",
  "libros": [
    {
      "titulo": "Cien años de soledad",
      "autor": "Gabriel García Márquez",
      "anioPublicacion": 1967,
      "genero": 1 // Ficción
    },
    {
      "titulo": "El amor en los tiempos del cólera",
      "autor": "Gabriel García Márquez",
      "anioPublicacion": 1985,
      "genero": 1 // Ficción
    }
  ]
}
```

---

### Importante
Hay un error en la parte donde se colaca el genero de el libro, el genero no se nota o no se puede ver en el espacio pero si se lo toma y queda registrado a el guardar, no pude arreglar este error
