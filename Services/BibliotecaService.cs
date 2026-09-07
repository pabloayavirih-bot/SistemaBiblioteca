using SistemaBiblioteca.Models;

namespace SistemaBiblioteca.Services;

public class BibliotecaService
{
    private List<Libro> libros = new List<Libro>();
    private List<Usuario> usuarios = new List<Usuario>();

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
}