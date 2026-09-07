using SistemaBiblioteca.Models;
using SistemaBiblioteca.Services;

Console.WriteLine("=================================");
Console.WriteLine("SISTEMA DE GESTIÓN DE BIBLIOTECA");
Console.WriteLine("=================================");



BibliotecaService biblioteca = new BibliotecaService();

Libro libro1 = new Libro(
    "El Principito",
    "Antoine de Saint-Exupéry",
    "Novela",
    "LIB001",
    true
);

Libro libro2 = new Libro(
    "1984",
    "George Orwell",
    "Distopía",
    "LIB002",
    true
);

biblioteca.RegistrarLibro(libro1);
biblioteca.RegistrarLibro(libro2);

foreach (Libro libro in biblioteca.ObtenerLibros())
{
    Console.WriteLine($"{libro.Codigo} - {libro.Titulo}");
}