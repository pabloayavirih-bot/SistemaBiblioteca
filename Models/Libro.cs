using SistemaBiblioteca.Interfaces;

namespace SistemaBiblioteca.Models;

public class Libro : IPrestable
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Categoria { get; set; }
    public string Codigo { get; set; }

    public bool Disponible { get; private set; }


    public Libro(
        string titulo,
        string autor,
        string categoria,
        string codigo,
        bool disponible)
    {
        Titulo = titulo;
        Autor = autor;
        Categoria = categoria;
        Codigo = codigo;
        Disponible = disponible;
    }


    public void Prestar()
    {
        if (!Disponible)
        {
            throw new InvalidOperationException(
                "El libro no está disponible."
            );
        }

        Disponible = false;
    }


    public void Devolver()
    {
        Disponible = true;
    }
}