using SistemaBiblioteca.Models;

namespace SistemaBiblioteca.Services;

public class BibliotecaService
{
    private List<Libro> libros = new List<Libro>();
    private List<Usuario> usuarios = new List<Usuario>();

    public void RegistrarLibro(Libro libro)
    {
        libros.Add(libro);
    }

    public void RegistrarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
    }

    public List<Libro> ObtenerLibros()
    {
        return libros;
    }

    public List<Usuario> ObtenerUsuarios()
    {
        return usuarios;
    }
}