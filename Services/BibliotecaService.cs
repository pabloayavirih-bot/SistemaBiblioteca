using SistemaBiblioteca.Models;

namespace SistemaBiblioteca.Services;

public class BibliotecaService
{
    private List<Libro> libros = new List<Libro>();
    private List<Usuario> usuarios = new List<Usuario>();
    private List<Prestamo> prestamos = new List<Prestamo>();


    public void RegistrarLibro(Libro libro)
    {
        if (string.IsNullOrWhiteSpace(libro.Titulo))
        {
            throw new ArgumentException(
                "El título del libro es obligatorio."
            );
        }

        if (string.IsNullOrWhiteSpace(libro.Autor))
        {
            throw new ArgumentException(
                "El autor del libro es obligatorio."
            );
        }

        if (string.IsNullOrWhiteSpace(libro.Codigo))
        {
            throw new ArgumentException(
                "El código del libro es obligatorio."
            );
        }

        Libro? libroExistente = libros.FirstOrDefault(
            libroGuardado =>
                libroGuardado.Codigo.Equals(
                    libro.Codigo,
                    StringComparison.OrdinalIgnoreCase
                )
        );

        if (libroExistente != null)
        {
            throw new InvalidOperationException(
                $"Ya existe un libro con el código {libro.Codigo}."
            );
        }

        libros.Add(libro);
    }


    public void RegistrarUsuario(Usuario usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Identificador))
        {
            throw new ArgumentException(
                "El identificador del usuario es obligatorio."
            );
        }

        if (string.IsNullOrWhiteSpace(usuario.Nombre))
        {
            throw new ArgumentException(
                "El nombre del usuario es obligatorio."
            );
        }

        if (string.IsNullOrWhiteSpace(usuario.Correo))
        {
            throw new ArgumentException(
                "El correo del usuario es obligatorio."
            );
        }

        Usuario? usuarioExistente = usuarios.FirstOrDefault(
            usuarioGuardado =>
                usuarioGuardado.Identificador.Equals(
                    usuario.Identificador,
                    StringComparison.OrdinalIgnoreCase
                )
        );

        if (usuarioExistente != null)
        {
            throw new InvalidOperationException(
                $"Ya existe un usuario con el identificador {usuario.Identificador}."
            );
        }

        usuarios.Add(usuario);
    }


    public List<Libro> ObtenerLibros()
    {
        return libros.ToList();
    }


    public List<Usuario> ObtenerUsuarios()
    {
        return usuarios.ToList();
    }


    public Libro? BuscarLibroPorCodigo(string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
        {
            throw new ArgumentException(
                "Debe ingresar un código para realizar la búsqueda."
            );
        }

        return libros.FirstOrDefault(
            libro =>
                libro.Codigo.Equals(
                    codigo,
                    StringComparison.OrdinalIgnoreCase
                )
        );
    }


    public void EliminarLibro(string codigo)
    {
        Libro? libroEncontrado = BuscarLibroPorCodigo(codigo);

        if (libroEncontrado == null)
        {
            throw new InvalidOperationException(
                $"No existe un libro con el código {codigo}."
            );
        }

        libros.Remove(libroEncontrado);
    }


    public void PrestarLibro(string codigoLibro)
    {
        Libro? libro = BuscarLibroPorCodigo(codigoLibro);

        if (libro == null)
        {
            throw new InvalidOperationException(
                "No existe el libro solicitado."
            );
        }

        libro.Prestar();
    }


    public void DevolverLibro(string codigoLibro)
    {
        Libro? libro = BuscarLibroPorCodigo(codigoLibro);

        if (libro == null)
        {
            throw new InvalidOperationException(
                "No existe el libro solicitado."
            );
        }

        libro.Devolver();
    }


    public void RegistrarPrestamo(
        string codigoLibro,
        string identificadorUsuario)
    {
        Libro? libro = BuscarLibroPorCodigo(codigoLibro);

        if (libro == null)
        {
            throw new InvalidOperationException(
                "No existe el libro solicitado."
            );
        }


        Usuario? usuario = usuarios.FirstOrDefault(
            usuarioGuardado =>
                usuarioGuardado.Identificador.Equals(
                    identificadorUsuario,
                    StringComparison.OrdinalIgnoreCase
                )
        );


        if (usuario == null)
        {
            throw new InvalidOperationException(
                "No existe el usuario solicitado."
            );
        }


        libro.Prestar();


        Prestamo nuevoPrestamo = new Prestamo(
            libro.Codigo,
            usuario.Identificador,
            DateTime.Now,
            null
        );


        prestamos.Add(nuevoPrestamo);
    }


    public void RegistrarDevolucion(string codigoLibro)
    {
        Prestamo? prestamo = prestamos.FirstOrDefault(
            prestamoActivo =>
                prestamoActivo.CodigoLibro.Equals(
                    codigoLibro,
                    StringComparison.OrdinalIgnoreCase
                )
                &&
                prestamoActivo.Activo
        );


        if (prestamo == null)
        {
            throw new InvalidOperationException(
                "No existe un préstamo activo para ese libro."
            );
        }


        Libro? libro = BuscarLibroPorCodigo(codigoLibro);


        if (libro == null)
        {
            throw new InvalidOperationException(
                "El libro no existe."
            );
        }


        libro.Devolver();


        Prestamo prestamoDevuelto = prestamo with
        {
            FechaDevolucion = DateTime.Now
        };


        prestamos.Remove(prestamo);

        prestamos.Add(prestamoDevuelto);
    }


    public List<Prestamo> ObtenerPrestamosActivos()
    {
        return prestamos
            .Where(prestamo => prestamo.Activo)
            .ToList();
    }


    public List<Libro> ObtenerLibrosDisponibles()
    {
        return libros
            .Where(libro => libro.Disponible)
            .ToList();
    }


    public List<Libro> BuscarLibros(string texto)
    {
        return libros
            .Where(libro =>
                libro.Autor.Contains(
                    texto,
                    StringComparison.OrdinalIgnoreCase
                )
                ||
                libro.Categoria.Contains(
                    texto,
                    StringComparison.OrdinalIgnoreCase
                )
            )
            .ToList();
    }


    public List<Libro> ObtenerLibrosOrdenados()
    {
        return libros
            .OrderBy(libro => libro.Titulo)
            .ToList();
    }


    public List<string> ObtenerResumenPrestamos()
    {
        return prestamos
            .Where(prestamo => prestamo.Activo)
            .Select(prestamo =>
                $"Libro: {prestamo.CodigoLibro} | Usuario: {prestamo.IdentificadorUsuario}"
            )
            .ToList();
    }
}